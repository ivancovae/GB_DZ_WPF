using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCompanyWatcher.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int DepartmentID { get; set; }
        public int CompanyID { get; set; }
    }
}