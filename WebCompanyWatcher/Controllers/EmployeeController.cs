using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebCompanyWatcher.Models;

namespace WebCompanyWatcher.Controllers
{
    public class EmployeeController : ApiController
    {
        private DataEmployee data = new DataEmployee();

        [Route("getEmployeeList")]
        public List<Employee> Get()
        {
            return data.getListEmployees();
        }
        [Route("getEmployeeListForDepartment/{Id}")]
        public List<Employee> GetEmployees(int Id)
        {
            return data.getListEmployeisForDepartment(Id);
        }
        [Route("getEmployeeListId/{Id}")]
        public Employee Get(int Id)
        {
            return data.getEmployeeId(Id);
        }
    }
}
