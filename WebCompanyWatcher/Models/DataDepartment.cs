using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace WebCompanyWatcher.Models
{
    /// <summary>
    /// Объект работы с источником данных для департаментов
    /// </summary>
    public class DataDepartment
    {
        private SqlConnection connection;
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public DataDepartment()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        /// <summary>
        /// получение списка департаментов
        /// </summary>
        /// <returns>список департаментов</returns>
        public List<Department> getListDepartments()
        {
            List<Department> list = new List<Department>();

            string sql = $@"SELECT Department.Name as DepartmentName, Department.Id as DepartmentId
                                                        FROM Department";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Department
                        {
                            Name = reader["DepartmentName"].ToString(),
                            ID = reader["DepartmentId"].ToString()
                        });
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// получение списка департаментов компании
        /// </summary>
        /// <param name="Id">уникальный номер компании</param>
        /// <returns>список департаментов</returns>
        public List<Department> getListDepartmentsForCompany(int Id)
        {
            List<Department> list = new List<Department>();

            string sql = $@"SELECT Department.Name as DepartmentName, Department.Id as DepartmentId
                                                        FROM Department
                                                        WHERE Department.CompanyID={Id}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Department
                        {
                            Name = reader["DepartmentName"].ToString(),
                            ID = reader["DepartmentId"].ToString()
                        });
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// получение департамента по уникальному номеру
        /// </summary>
        /// <param name="Id">уникальный номер департамента</param>
        /// <returns>объект департамента</returns>
        public Department getDepartmentId(int Id)
        {
            Department department = new Department();

            string sql = $@"SELECT Department.Name as DepartmentName, Department.Id as DepartmentId
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
                            Name = reader["DepartmentName"].ToString(),
                            ID = reader["DepartmentId"].ToString()
                        };
                    }
                }
            }
            return department;
        }
    }
}