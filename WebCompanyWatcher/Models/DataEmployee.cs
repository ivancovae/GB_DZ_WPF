using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace WebCompanyWatcher.Models
{
    public class DataEmployee
    {
        private SqlConnection connection;
        public DataEmployee()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

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