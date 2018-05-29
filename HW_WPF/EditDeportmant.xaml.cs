using System.Text;
using System.Windows;
using System.Net.Http;
using System.IO;
using System.Runtime.Serialization.Json;
using HW_WPF.Model;

namespace HW_WPF
{
    /// <summary>
    /// Interaction logic for EditDeportmant.xaml
    /// </summary>
    public partial class EditDeportmant : Window
    {
        private string host = $"http://localhost:50523/";
        public EditDeportmant(int Id)
        {
            InitializeComponent();
                        
            Loaded += (s, e) => {
                string url = host + $@"getDepartmentListId/{Id}";
                HttpClient httpClient = new HttpClient();
                DataContractJsonSerializer jsonCompanyFormatter = new DataContractJsonSerializer(typeof(DepartmentTable));
                DepartmentTable ct = (DepartmentTable)jsonCompanyFormatter.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(httpClient.GetStringAsync(url).Result)));
                TextBoxDepartment.Text = ct.Name;
                string urlDep = host + $@"getEmployeeListForDepartment/{ct.ID}";
                DataContractJsonSerializer jsonDepartmentFormatter = new DataContractJsonSerializer(typeof(EmployeeTable[]));
                EmployeeTable[] dt = (EmployeeTable[])jsonDepartmentFormatter.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(httpClient.GetStringAsync(urlDep).Result)));
                EmployeesDataGrid.ItemsSource = dt;
            };
            Closing += (s, e) => {

            };
            btnShowEmployee.Click += (s, e) => {
                if (EmployeesDataGrid.SelectedItem != null)
                {
                    EditEmpoyee editWindow = new EditEmpoyee(((EmployeeTable)EmployeesDataGrid.SelectedItem).ID);
                    editWindow.Show();
                }
            };
        }
    }
}
