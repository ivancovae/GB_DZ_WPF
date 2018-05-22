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
    /// Interaction logic for EditEmpoyee.xaml
    /// </summary>
    public partial class EditEmpoyee : Window, IEmployeeView
    {
        public string EmployeeName
        {
            get
            {
                return textBoxEmployeeName.Text;
            }

            set
            {
                textBoxEmployeeName.Text = value;
            }
        }

        public string EmployeeAge
        {
            get
            {
                return textBoxEmployeeAge.Text;
            }

            set
            {
                textBoxEmployeeAge.Text = value;
            }
        }

        public string EmployeeSalary
        {
            get
            {
                return textBoxEmployeeSalary.Text;
            }

            set
            {
                textBoxEmployeeSalary.Text = value;
            }
        }

        public List<string> Deportments
        {
            get
            {
                return comboBoxEmployeeDepartment.ItemsSource as List<string>;
            }

            set
            {
                comboBoxEmployeeDepartment.ItemsSource = value;
            }
        }

        public string EmployeeDepartment
        {
            get
            {
                return comboBoxEmployeeDepartment.SelectedValue as string;
            }

            set
            {
                comboBoxEmployeeDepartment.SelectedValue = value; 
            }
        }

        /// <summary>
        /// Конструктор по уполчанию
        /// </summary>
        public EditEmpoyee()
        {
            InitializeComponent();
        }

        private void btnSaveEmployee_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btnCancelEmployee_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
