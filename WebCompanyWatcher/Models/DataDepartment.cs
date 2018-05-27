using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace WebCompanyWatcher.Models
{
    public class DataDepartment
    {
        private SqlConnection connection;
        public DataDepartment()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public List<Department> getListDepartments()
        {
            List<Department> list = new List<Department>();

            string sql = $@"SELECT Department.Name as DepartmentName
                                                        FROM Department";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Department
                        {
                            Name = reader["DepartmentName"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public Department getDepartmentId(int Id)
        {
            Department department = new Department();

            string sql = $@"SELECT Department.Name as DepartmentName
                                                        FROM Department
                                                        WHERE Department.Id={Id}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        department = new Department
                        {
                            Name = reader["DepartmentName"].ToString()
                        };
                    }
                }
            }
            return department;
        }

        public bool AddDepartment(Department department)
        {
            try
            {
                string sql = $@"INSERT INTO Department (Name) 
                                VALUES (N'{department.Name})";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}