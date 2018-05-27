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
        [Route("getEmployeeListId")]
        public Employee Get(int Id)
        {
            return data.getEmployeeId(Id);
        }
        [Route("addEmployee")]
        public HttpResponseMessage Post([FromBody]Employee value)
        {
            if (data.AddEmployee(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
