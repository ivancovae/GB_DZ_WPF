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

namespace HW_WPF
{
    /// <summary>
    /// Interaction logic for EditDeportmant.xaml
    /// </summary>
    public partial class EditDeportmant : Window, IDepartmentView
    {
        #region IDepartmentView
        public string DepartmentName
        {
            get
            {
                return TextBoxDepartment.Text;
            }

            set
            {
                TextBoxDepartment.Text = value;
            }
        }

        public List<string> Employees
        {
            get
            {
                return listBoxEmployees.ItemsSource as List<string>;
            }

            set
            {
                listBoxEmployees.ItemsSource = value;
            }
        }

        public string SelectedEmployee
        {
            get
            {
                return listBoxEmployees.SelectedValue as string;
            }

            set
            {
                listBoxEmployees.SelectedValue = value;
            }
        }
        #endregion

        private IPresenter p;

        public EditDeportmant()
        {
            InitializeComponent();
        }
        public EditDeportmant(IModel model)
        {
            InitializeComponent();
            p = new DepartmentPresenter(this, model);

            Loaded += (s, e) => { p.LoadData(); };
            Closing += (s, e) => { p.SaveData(); };
            btnAddEmployee.Click += (s, e) => { p.Show(); };
            btnEditEmployee.Click += (s, e) => { p.Edit(); };
            btnRemoveEmployee.Click += (s, e) => { p.Remove(); };
        }
    }
}
