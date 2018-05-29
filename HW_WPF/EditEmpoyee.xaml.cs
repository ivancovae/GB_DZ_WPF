using System.Text;
using System.Windows;
using System.Net.Http;
using System.IO;
using System.Runtime.Serialization.Json;
using HW_WPF.Model;

namespace HW_WPF
{
    /// <summary>
    /// Interaction logic for EditEmpoyee.xaml
    /// </summary>
    public partial class EditEmpoyee : Window
    {
        private string host = $"http://localhost:50523/";

        public EditEmpoyee(int Id)
        {
            InitializeComponent();
            
            Loaded += (s, e) => {
                HttpClient httpClient = new HttpClient();
                string url = host + $@"getEmployeeListId/{Id}";
                DataContractJsonSerializer jsonEmployeeFormatter = new DataContractJsonSerializer(typeof(EmployeeTable));
                EmployeeTable et = (EmployeeTable)jsonEmployeeFormatter.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(httpClient.GetStringAsync(url).Result)));
                
                textBoxEmployeeName.Text = et.Name;
                textBoxEmployeeAge.Text = et.Age.ToString();
                textBoxEmployeeSalary.Text = et.Salary.ToString();
            };
            Closing += (s, e) => {

            };
        }
    }
}
