using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HW_WPF
{
    /// <summary>
    /// Interaction logic for EditDeportmant.xaml
    /// </summary>
    public partial class EditDeportmant : Window
    {
        // 
        // Заголовок (DepartmentName, CompanyName, DepartmentID)
        // 
        /// <summary>
        /// Свойство результата строки
        /// </summary>
        public DataRow resultRow { get; set; }

        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dt;

        private void AddSelectCommand()
        {
            SqlCommand sqlCommand = new SqlCommand(@"SELECT Employee.Id as EmployeeID, Employee.Name as EmployeeName, Employee.Age as EmployeeAge, Employee.Salary as EmployeeSalary, Employee.CompanyID as CompanyID, Employee.DepartmentID as DepartmentID, Department.Name as DepartmentName
                                                        FROM Department 
                                                        INNER JOIN Employee 
                                                        ON Department.Id=Employee.DepartmentID 
                                                        WHERE Department.Id=@ID", connection);
            SqlParameter sqlParam = new SqlParameter("@ID", SqlDbType.Int, 0, "ID");
            sqlParam.SourceVersion = DataRowVersion.Original;
            sqlParam.Value = resultRow["DepartmentID"];
            sqlCommand.Parameters.Add(sqlParam);
            adapter.SelectCommand = sqlCommand;
        }
        private void AddInsertCommand()
        {
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Employee (Name, Age, Salary, DepartmentId, CompanyId) VALUES (@Name, @Age, @Salary, @DepartmentId, @CompanyId); SET @ID = @@IDENTITY;", connection);
            sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "EmployeeName");
            sqlCommand.Parameters.Add("@Age", SqlDbType.NVarChar, -1, "EmployeeAge");
            sqlCommand.Parameters.Add("@Salary", SqlDbType.NVarChar, -1, "EmployeeSalary");
            sqlCommand.Parameters.Add("@DepartmentId", SqlDbType.NVarChar, -1, "DepartmentID");
            sqlCommand.Parameters.Add("@CompanyId", SqlDbType.Int, 0, "CompanyID");
            SqlParameter param = sqlCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "EmployeeID");
            param.Direction = ParameterDirection.Output;
            adapter.InsertCommand = sqlCommand;
        }
        private void AddUpdateCommand()
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE Employee SET Name = @Name, Age = @Age, Salary = @Salary, DepartmentId = @DepartmentId, CompanyId = @CompanyId WHERE ID = @ID", connection);
            sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "EmployeeName");
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int, 0, "EmployeeAge");
            sqlCommand.Parameters.Add("@Salary", SqlDbType.Int, 0, "EmployeeSalary");
            sqlCommand.Parameters.Add("@DepartmentId", SqlDbType.Int, 0, "DepartmentID");
            sqlCommand.Parameters.Add("@CompanyId", SqlDbType.Int, 0, "CompanyID");
            SqlParameter param = sqlCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "EmployeeID");
            param.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand = sqlCommand;
        }
        private void AddDeleteCommand()
        {
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Employee WHERE ID = @ID", connection);
            SqlParameter param = sqlCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "EmployeeID");
            
            param.SourceVersion = DataRowVersion.Original;
            adapter.DeleteCommand = sqlCommand;
        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="sqlConnection">конекшен к базе</param>
        /// <param name="dataRow">строка в таблице</param>
        public EditDeportmant(SqlConnection sqlConnection, DataRow dataRow)
        {
            InitializeComponent();
            resultRow = dataRow;

            connection = sqlConnection;
            
            Loaded += (s, e) => {
                adapter = new SqlDataAdapter();
                AddSelectCommand();
                AddInsertCommand();
                AddUpdateCommand();
                AddDeleteCommand();
                dt = new DataTable();
                adapter.Fill(dt);

                EmployeesDataGrid.DataContext = dt.DefaultView;
                TextBoxDepartment.Text = resultRow["DepartmentName"] != null ? resultRow["DepartmentName"].ToString() : "Новый департамент";
            };
            Closing += (s, e) => {

            };
            btnSaveEmployee.Click += (s, e) => {
                resultRow["DepartmentName"] = TextBoxDepartment.Text;
                DialogResult = true;
            };
            btnAddEmployee.Click += (s, e) => {
                DataRow newRow = dt.NewRow();
                newRow["DepartmentName"] = TextBoxDepartment.Text;
                EditEmpoyee editWindow = new EditEmpoyee(connection, newRow);
                editWindow.ShowDialog();
                if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
                {
                    newRow["CompanyID"] = resultRow["CompanyID"].ToString();
                    dt.Rows.Add(editWindow.resultRow);
                    adapter.Update(dt);
                    if (newRow["DepartmentID"].ToString() != resultRow["DepartmentID"].ToString())
                    {
                        dt.Rows.Remove(editWindow.resultRow);
                    }
                }
            };
            btnEditEmployee.Click += (s, e) => {
                if (EmployeesDataGrid.SelectedItem != null)
                {
                    DataRowView newRow = (DataRowView)EmployeesDataGrid.SelectedItem;
                    newRow["CompanyID"] = resultRow["CompanyID"].ToString();
                    newRow.BeginEdit();
                    EditEmpoyee editWindow = new EditEmpoyee(connection, newRow.Row);
                    editWindow.ShowDialog();
                    if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
                    {
                        newRow.EndEdit();
                        adapter.Update(dt);
                        if (newRow["DepartmentID"].ToString() != resultRow["DepartmentID"].ToString())
                        {
                            dt.Rows.Remove(newRow.Row);
                        }
                    }
                    else
                    {
                        newRow.CancelEdit();
                    }
                }
            };
            btnRemoveEmployee.Click += (s, e) => {
                if (EmployeesDataGrid.SelectedItem != null)
                {
                    DataRowView newRow = (DataRowView)EmployeesDataGrid.SelectedItem;
                    newRow.Row.Delete();
                    adapter.Update(dt);
                }
            };
        }
    }
}
