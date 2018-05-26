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

namespace HW_WPF
{
    /// <summary>
    /// Interaction logic for EditEmpoyee.xaml
    /// </summary>
    public partial class EditEmpoyee : Window
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dt;

        private void AddSelectCommand()
        {
            SqlCommand sqlCommand = new SqlCommand(@"SELECT Department.Id as DepartmentID, Department.Name as DepartmentName
                                                        FROM Department 
                                                        INNER JOIN Company 
                                                        ON Department.CompanyID=Company.Id", connection);
            adapter.SelectCommand = sqlCommand;
        }
        //
        // EmployeID, EmployeeName, EmployeeAge, EmployeeSalary, CompanyID, DepartmentID, DepartmentName 
        //
        /// <summary>
        /// Свойство результата строки
        /// </summary>
        public DataRow resultRow { get; set; }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="sqlConnection">конекшен к базе</param>
        /// <param name="dataRow">строка в таблице</param>
        public EditEmpoyee(SqlConnection sqlConnection, DataRow dataRow)
        {
            InitializeComponent();
            resultRow = dataRow;

            connection = sqlConnection;
            adapter = new SqlDataAdapter();
            AddSelectCommand();
            dt = new DataTable();
            adapter.Fill(dt);

            Loaded += (s, e) => {
                textBoxEmployeeName.Text = resultRow["EmployeeName"].ToString();
                textBoxEmployeeAge.Text = resultRow["EmployeeAge"].ToString();
                textBoxEmployeeSalary.Text = resultRow["EmployeeSalary"].ToString();
                comboBoxEmployeeDepartment.ItemsSource = dt.DefaultView;
                for (var i = 0; i < dt.DefaultView.Count; i++)
                {
                    DataRowView drv = dt.DefaultView[i];
                    if (drv.Row["DepartmentName"].ToString() == resultRow["DepartmentName"].ToString())
                    {
                        comboBoxEmployeeDepartment.SelectedIndex = i;
                        break;
                    }
                }                
            };
            Closing += (s, e) => {

            };
            SaveEmployee.Click += (s, e) =>
            {
                resultRow["EmployeeName"] = textBoxEmployeeName.Text;
                resultRow["EmployeeAge"] = textBoxEmployeeAge.Text;
                resultRow["EmployeeSalary"] = textBoxEmployeeSalary.Text;
                resultRow["DepartmentID"] = (comboBoxEmployeeDepartment.SelectedItem as DataRowView).Row["DepartmentID"];
                resultRow["DepartmentName"] = (comboBoxEmployeeDepartment.SelectedItem as DataRowView).Row["DepartmentName"];
                DialogResult = true;
            };
            CancelEmployee.Click += (s, e) =>
            {
                DialogResult = true;
            };
        }
    }
}
