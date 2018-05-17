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

            /*Employee directorCompany = new Employee("Иван", "Иванов");
            Company company = new Company("Рога и Копыта");

            Employee directorDepartment = new Employee("Антон", "Иванов");
            company.AddNewDepartment("Програмных технологий");
            company.AddNewDepartment("Сетевых технологий");

            var departments = company.Departments;

            Employee employee00 = new Employee("Константин", "Иванов");
            departments[0].AddNewEmployee(employee00);

            Employee employee01 = new Employee("Сергей", "Иванов");
            departments[0].AddNewEmployee(employee01);

            employee00.ChangeDepartment(departments[1]);*/
        }

        private void btnAddDepartment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveDepartment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditDepartment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
