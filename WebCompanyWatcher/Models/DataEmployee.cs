using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace WebCompanyWatcher.Models
{
    /// <summary>
    /// Объект работы с источником данных для сотрудников
    /// </summary>
    public class DataEmployee
    {
        private SqlConnection connection;
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public DataEmployee()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        /// <summary>
        /// получение списка сотрудников
        /// </summary>
        /// <returns>список сотрудников</returns>
        public List<Employee> getListEmployees()
        {
            List<Employee> list = new List<Employee>();

            string sql = $@"SELECT Employee.Name as EmployeeName, Employee.Age as EmployeeAge, Employee.Salary as EmployeeSalary, Employee.Id as EmployeeID
                                                        FROM Employee";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            list.Add(new Employee()
                            {
                                Name = reader["EmployeeName"].ToString(),
                                Age = Convert.ToInt32(reader["EmployeeAge"]),
                                Salary = Convert.ToInt32(reader["EmployeeSalary"]),
                                ID = reader["EmployeeID"].ToString()
                            });
                        }
                        catch (System.InvalidCastException ex)
                        {
                            Console.WriteLine($"Часть данных полученных из сервиса не корректны " + Environment.NewLine + ex.Message);
                        }
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// получение списка сотрудников департамента
        /// </summary>
        /// <param name="Id">уникальный номер департамента</param>
        /// <returns>список сотрудников</returns>
        public List<Employee> getListEmployeisForDepartment(int Id)
        {
            List<Employee> list = new List<Employee>();

            string sql = $@"SELECT Employee.Name as EmployeeName, Employee.Age as EmployeeAge, Employee.Salary as EmployeeSalary, Employee.Id as EmployeeID
                                                        FROM Employee
                                                        WHERE Employee.DepartmentId={Id}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Employee
                        {
                            Name = reader["EmployeeName"].ToString(),
                            Age = Convert.ToInt32(reader["EmployeeAge"]),
                            Salary = Convert.ToInt32(reader["EmployeeSalary"]),
                            ID = reader["EmployeeID"].ToString()
                        });
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// получение сотрудника
        /// </summary>
        /// <param name="Id">уникальный номер сотрудника</param>
        /// <returns>объект сотрудника</returns>
        public Employee getEmployeeId(int Id)
        {
            Employee employee = new Employee();

            string sql = $@"SELECT Employee.Name as EmployeeName, Employee.Age as EmployeeAge, Employee.Salary as EmployeeSalary, Employee.Id as EmployeeID
                                                        FROM Employee
                                                        WHERE Employee.Id={Id}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employee = new Employee
                        {
                            Name = reader["EmployeeName"].ToString(),
                            Age = Convert.ToInt32(reader["EmployeeAge"]),
                            Salary = Convert.ToInt32(reader["EmployeeSalary"]),
                            ID = reader["EmployeeID"].ToString()
                        };
                    }
                }
            }
            return employee;
        }
    }
}