using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WebCompanyWatcher.Models
{
    public class DataCompany
    {
        private SqlConnection connection;
        public DataCompany()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

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