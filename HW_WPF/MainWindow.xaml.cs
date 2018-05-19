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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            EditDeportmant editDeportmantWindow = new EditDeportmant();
            var context = editDeportmantWindow.DataContext;
            if (context is EditDeportmentViewModel)
            {
                var deportmentVM = context as EditDeportmentViewModel;
                var name = "Новый департамент";
                deportmentVM.Department = new Department(name);
                deportmentVM.DepartmentName = name;
            }
            bool? result = editDeportmantWindow.ShowDialog();

            if (result.HasValue && result.Value)
            {
                if (editDeportmantWindow.DataContext is EditDeportmentViewModel)
                {
                    Department departament = (editDeportmantWindow.DataContext as EditDeportmentViewModel).Department;
                    if(DataContext is MainViewModel)
                    {
                        (DataContext as MainViewModel).AddDepartment(departament);
                    }
                }
            }            
        }

        private void btnRemoveDepartment_Click(object sender, RoutedEventArgs e)
        {
            var value = listBoxDepartments.SelectedValue;
            if (value is string)
            {
                (DataContext as MainViewModel).RemoveDepartment((value as string));
            }

        }

        private void btnEditDepartment_Click(object sender, RoutedEventArgs e)
        {
            EditDeportmant editDeportmantWindow = new EditDeportmant();
            var context = editDeportmantWindow.DataContext;
            if (context is EditDeportmentViewModel)
            {
                var deportmentVM = context as EditDeportmentViewModel;
                var value = listBoxDepartments.SelectedValue;
                if (value is string && value != null)
                {
                    var name = value as string;
                    if (DataContext is MainViewModel)
                    {
                        deportmentVM.Department = (DataContext as MainViewModel).GetDepartment(name);
                    }
                    deportmentVM.DepartmentName = name;

                    bool? result = editDeportmantWindow.ShowDialog();
                    if (result.HasValue && result.Value)
                    {
                        if (editDeportmantWindow.DataContext is EditDeportmentViewModel)
                        {
                            if (DataContext is MainViewModel)
                            {
                                (DataContext as MainViewModel).UpdateDepartments((editDeportmantWindow.DataContext as EditDeportmentViewModel).Department);
                            }
                        }
                    }
                }
            }
            
        }
    }
}
