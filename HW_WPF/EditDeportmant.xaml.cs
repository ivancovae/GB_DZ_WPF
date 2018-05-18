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
    public partial class EditDeportmant : Window
    {
        public EditDeportmant()
        {
            InitializeComponent();
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            //EditEmpoyee editEmpoyeeWindow = new EditEmpoyee();
            //var context = editEmpoyeeWindow.DataContext;
            //if (context is EditEmployeeViewModel)
            //{
            //    var employeeVM = context as EditEmployeeViewModel;
            //    var name = "Новый департамент";
            //    employeeVM.Department = new Department(name);
            //    employeeVM.DepartmentName = name;
            //}
            //bool? result = editDeportmantWindow.ShowDialog();

            //if (result.HasValue && result.Value)
            //{
            //    if (editDeportmantWindow.DataContext is EditDeportmentViewModel)
            //    {
            //        Department departament = (editDeportmantWindow.DataContext as EditDeportmentViewModel).Department;
            //        if (DataContext is MainViewModel)
            //        {
            //            (DataContext as MainViewModel).AddDepartment(departament);
            //        }
            //    }
            //}
        }

        private void btnRemoveEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSaveDepartment_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btnCancelDepartment_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
