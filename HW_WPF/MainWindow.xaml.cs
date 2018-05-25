using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HW_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dt;

        private void AddSelectCommand()
        {
            SqlCommand sqlCommand = new SqlCommand(@"SELECT Department.Name as DepartmentName, Company.Id as CompanyID, Company.Name as CompanyName, Department.Id as DepartmentID 
                                                        FROM Company 
                                                        INNER JOIN Department 
                                                        ON Company.Id=Department.CompanyID 
                                                        WHERE Company.Id=@ID", connection);
            SqlParameter sqlParam = new SqlParameter("@ID", SqlDbType.Int, 0, "ID");
            sqlParam.SourceVersion = DataRowVersion.Original;
            sqlParam.Value = 1;
            sqlCommand.Parameters.Add(sqlParam);
            adapter.SelectCommand = sqlCommand;
        }
        private void AddInsertCommand()
        {
            SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Department (Name, CompanyID) VALUES (@Name, @CompanyID); 
                                                        SET @ID = @@IDENTITY;", connection);
            sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "DepartmentName");
            sqlCommand.Parameters.Add("@CompanyID", SqlDbType.Int, 0, "CompanyID");
            SqlParameter param = sqlCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "DepartmentID");
            param.Direction = ParameterDirection.Output;
            adapter.InsertCommand = sqlCommand;
        }
        private void AddUpdateCommand()
        {
            SqlCommand sqlCommand = new SqlCommand(@"UPDATE Department SET Name = @Name, CompanyID = @CompanyID
                                                        WHERE ID = @ID", connection);
            sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "DepartmentName");
            sqlCommand.Parameters.Add("@CompanyID", SqlDbType.Int, 0, "CompanyID");
            SqlParameter param = sqlCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "DepartmentID");
            param.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand = sqlCommand;
        }
        private void AddDeleteCommand()
        {
            SqlCommand sqlCommand = new SqlCommand(@"DELETE FROM Department 
                                                        WHERE ID = @ID", connection);
            SqlParameter param = sqlCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "DepartmentID");
            param.SourceVersion = DataRowVersion.Original;
            adapter.DeleteCommand = sqlCommand;
        }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) => {
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
                adapter = new SqlDataAdapter();
                AddSelectCommand();
                AddInsertCommand();
                AddUpdateCommand();
                AddDeleteCommand();
                dt = new DataTable();
                adapter.Fill(dt);
                DeportmentDataGrid.DataContext = dt.DefaultView;
                TextBoxCompany.Text = dt.DefaultView[0]["CompanyName"].ToString();
            };
            Closing += (s, e) => {

            };
            btnAddDepartment.Click += (s, e) => {
                DataRow newRow = dt.NewRow();
                EditDeportmant editWindow = new EditDeportmant(connection, newRow);
                editWindow.ShowDialog();
                if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
                {
                    newRow["CompanyName"] = dt.DefaultView[0]["CompanyName"].ToString();
                    newRow["CompanyID"] = dt.DefaultView[0]["CompanyID"].ToString();
                    dt.Rows.Add(editWindow.resultRow);
                    adapter.Update(dt);
                }
            };
            btnEditDepartment.Click += (s, e) => {
                if (DeportmentDataGrid.SelectedItem != null)
                {
                    DataRowView newRow = (DataRowView)DeportmentDataGrid.SelectedItem;
                    newRow.BeginEdit();
                    EditDeportmant editWindow = new EditDeportmant(connection, newRow.Row);
                    editWindow.ShowDialog();
                    if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
                    {
                        newRow.EndEdit();
                        adapter.Update(dt);
                    }
                    else
                    {
                        newRow.CancelEdit();
                    }
                }
            };
            btnRemoveDepartment.Click += (s, e) => {
                if (DeportmentDataGrid.SelectedItem != null)
                {
                    DataRowView newRow = (DataRowView)DeportmentDataGrid.SelectedItem;
                    newRow.Row.Delete();
                    adapter.Update(dt);
                }
            };
        }
    }
}
