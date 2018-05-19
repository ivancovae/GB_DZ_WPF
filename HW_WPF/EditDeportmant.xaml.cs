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
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public EditDeportmant()
        {
            InitializeComponent();
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            EditEmpoyee editEmpoyeeWindow = new EditEmpoyee();
            var context = editEmpoyeeWindow.DataContext;
            if (context is EditEmployeeViewModel)
            {
                var employeeVM = context as EditEmployeeViewModel;
                var name = "Без имени";
                var surname = "Без фамилии";
                employeeVM.Employee = new Employee(name, surname);
                employeeVM.EmployeeName = name;
                employeeVM.EmployeeSurname = surname;
            }
            bool? result = editEmpoyeeWindow.ShowDialog();

            if (result.HasValue && result.Value)
            {
                if (editEmpoyeeWindow.DataContext is EditEmployeeViewModel)
                {
                    Employee employee = (editEmpoyeeWindow.DataContext as EditEmployeeViewModel).Employee;
                    if (DataContext is EditDeportmentViewModel)
                    {
                        var temp = (DataContext as EditDeportmentViewModel);
                        employee.ChangeDepartment(temp.Department);
                        temp.AddEmployee(employee);
                        temp.UpdateEmployees(employee);
                    }
                }
            }
        }

        private void btnRemoveEmployee_Click(object sender, RoutedEventArgs e)
        {
            var value = listBoxEmployees.SelectedValue;
            if (value is string)
            {
                (DataContext as EditDeportmentViewModel).RemoveEmployee((value as string));
            }
        }

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            EditEmpoyee editEmpoyeeWindow = new EditEmpoyee();
            var context = editEmpoyeeWindow.DataContext;
            if (context is EditEmployeeViewModel)
            {
                var employeeVM = context as EditEmployeeViewModel;
                var value = listBoxEmployees.SelectedValue;
                if (value is string && value != null)
                {
                    var name = value as string;
                    if (DataContext is EditDeportmentViewModel)
                    {
                        employeeVM.Employee = (DataContext as EditDeportmentViewModel).GetEmployee(name);
                    }
                    bool? result = editEmpoyeeWindow.ShowDialog();
                    if (result.HasValue && result.Value)
                    {
                        if (editEmpoyeeWindow.DataContext is EditEmployeeViewModel)
                        {
                            if (DataContext is EditDeportmentViewModel)
                            {
                                (DataContext as EditDeportmentViewModel).UpdateEmployees((editEmpoyeeWindow.DataContext as EditEmployeeViewModel).Employee);
                            }
                        }
                    }
                }
            }
            
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
