using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace HW_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Company _company = Current.Resources["Company"] as Company;
            _company.RenameCompany("Рога и Копыта");
            Employee e00 = new Employee("Иван", "Иванов");
            Employee e01 = new Employee("Сергей", "Сидоров");
            Employee e02 = new Employee("Петр", "Парфенов");
            Employee e03 = new Employee("Антон", "Носов");
            Employee e04 = new Employee("Степан", "Град");
            Employee e05 = new Employee("Николай", "Коконов");
            Employee e06 = new Employee("Михаил", "Борисов");
            Department d00 = new Department("Программных Технологий");
            d00.AddNewEmployee(e00);
            d00.AddNewEmployee(e01);
            d00.AddNewEmployee(e02);
            Department d01 = new Department("Сетевых Технологий");
            d01.AddNewEmployee(e03);
            Department d02 = new Department("Маркетинга");
            d02.AddNewEmployee(e04);
            d02.AddNewEmployee(e05);
            Department d03 = new Department("Финансов");
            d03.AddNewEmployee(e06);
            _company.AddNewDepartment(d00);
            _company.AddNewDepartment(d01);
            _company.AddNewDepartment(d02);
            _company.AddNewDepartment(d03);
        }
    }
}
