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
    public partial class MainWindow : Window, ICompanyView
    {
        #region iCompanyView
        public string CompanyName
        {
            get
            {
                return TextBoxCompany.Text;
            }

            set
            {
                TextBoxCompany.Text = value;
            }
        }

        public List<string> Departments
        {
            get
            {
                return listBoxDepartments.ItemsSource as List<string>;
            }
            set
            {
                listBoxDepartments.ItemsSource = value;
            }
        }

        public string SelectedDepartment
        {
            get
            {
                return listBoxDepartments.SelectedValue as string;
            }

            set
            {
                listBoxDepartments.SelectedValue = value;
            }
        }
        #endregion

        private IPresenter p;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand sqlCommand = new SqlCommand("SELECT Department.Name FROM Company INNER JOIN Department ON Company.Id=Department.CompanyID WHERE Company.Id=@ID", connection);
                SqlParameter sqlParam = new SqlParameter("@ID", SqlDbType.Int, 0, "ID");
                sqlParam.SourceVersion = DataRowVersion.Original;
                sqlParam.Value = 1;
                sqlCommand.Parameters.Add(sqlParam);
                adapter.SelectCommand = sqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DeportmentDataGrid.DataContext = dt.DefaultView;
            }

            p = new CompanyPresenter(this);
            Loaded += (s, e) => { p.LoadData(); };
            Closing += (s, e) => { p.SaveData(); };
            btnAddDepartment.Click += (s, e) => { p.Show(); };
            btnEditDepartment.Click += (s, e) => { p.Edit(); };
            btnRemoveDepartment.Click += (s, e) => { p.Remove(); };
        }
    }
}
