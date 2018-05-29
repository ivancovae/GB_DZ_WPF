using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WebCompanyWatcher.Models
{
    /// <summary>
    /// Объект работы с источником данных для компаний
    /// </summary>
    public class DataCompany
    {
        private SqlConnection connection;
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public DataCompany()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        /// <summary>
        /// получение списка компаний
        /// </summary>
        /// <returns>список компаний</returns>
        public List<Company> getListCompanies()
        {
            List<Company> list = new List<Company>();

            string sql = @"SELECT Company.Name as CompanyName, Company.Id as CompanyId
                                                        FROM Company";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        list.Add(new Company
                        {
                            Name = reader["CompanyName"].ToString(),
                            ID = reader["CompanyId"].ToString()
                        });
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// получения компании по уникальному номеру
        /// </summary>
        /// <param name="Id">уникальный номер компании</param>
        /// <returns>объект компании</returns>
        public Company getCompanyId(int Id)
        {
            Company company = new Company();

            string sql = $@"SELECT Company.Name as CompanyName, Company.Id as CompanyId
                                                        FROM Company
                                                        WHERE Company.Id={Id}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        company = new Company
                        {
                            Name = reader["CompanyName"].ToString(),
                            ID = reader["CompanyId"].ToString()
                        };
                    }
                }
            }
            return company;
        }
    }
}