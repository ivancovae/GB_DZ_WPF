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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            EditDeportmant editDeportmantWindow = new EditDeportmant();
            bool? result = editDeportmantWindow.ShowDialog();
            if(result.HasValue && result.Value)
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

        }

        private void btnEditDepartment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
