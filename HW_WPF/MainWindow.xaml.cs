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
            p = new CompanyPresenter(this);
            Loaded += (s, e) => { p.LoadData(); };
            Closing += (s, e) => { p.SaveData(); };
            btnAddDepartment.Click += (s, e) => { p.Show(); };
            btnEditDepartment.Click += (s, e) => { p.Edit(); };
            btnRemoveDepartment.Click += (s, e) => { p.Remove(); };
        }
    }
}
