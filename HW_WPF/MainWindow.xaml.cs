using System.Linq;
using System.Text;
using System.Windows;
using System.Net.Http;
using System.IO;
using System.Runtime.Serialization.Json;
using HW_WPF.Model;

namespace HW_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string host = $"http://localhost:50523/";
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) => {
                string url = host + $@"getCompanyList";
                HttpClient httpClient = new HttpClient();
                DataContractJsonSerializer jsonCompanyFormatter = new DataContractJsonSerializer(typeof(CompanyTable[]));
                CompanyTable[] ct = (CompanyTable[])jsonCompanyFormatter.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(httpClient.GetStringAsync(url).Result)));
                CompanyTable first = ct.First();
                TextBoxCompany.Text = first.Name;
                string urlDep = host + $@"getDepartmentsListForCompany/{first.ID}";
                DataContractJsonSerializer jsonDepartmentFormatter = new DataContractJsonSerializer(typeof(DepartmentTable[]));
                DepartmentTable[] dt = (DepartmentTable[])jsonDepartmentFormatter.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(httpClient.GetStringAsync(urlDep).Result)));
                DeportmentDataGrid.ItemsSource = dt;
            };
            Closing += (s, e) => {

            };
            
            btnShowDepartment.Click += (s, e) => {
                if (DeportmentDataGrid.SelectedItem != null)
                {
                    EditDeportmant editWindow = new EditDeportmant(((DepartmentTable)DeportmentDataGrid.SelectedItem).ID);
                    editWindow.Show();
                }
            };
        }
    }
}
