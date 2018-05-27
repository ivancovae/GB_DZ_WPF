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

            string sql = @"SELECT Department.Name as DepartmentName, Company.Id as CompanyID, Company.Name as CompanyName, Department.Id as DepartmentID
                                                        FROM Company
                                                        INNER JOIN Department
                                                        ON Company.Id = Department.CompanyID";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        list.Add(new Company
                        {
                            Name = reader["CompanyName"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public Company getCompanyId(int Id)
        {
            Company company = new Company();

            string sql = $@"SELECT Department.Name as DepartmentName, Company.Id as CompanyID, Company.Name as CompanyName, Department.Id as DepartmentID
                                                        FROM Company
                                                        INNER JOIN Department
                                                        ON Company.Id = Department.CompanyID
                                                        WHERE Company.Id={Id}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        company = new Company
                        {
                            Name = reader["CompanyName"].ToString()
                        };
                    }
                }
            }
            return company;
        }

        public bool AddCompany(Company company)
        {
            try
            {
                string sql = $@"INSERT INTO Company (Name) 
                                VALUES (N'{company.Name})";
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