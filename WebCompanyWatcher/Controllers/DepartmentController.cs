using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebCompanyWatcher.Models;

namespace WebCompanyWatcher.Controllers
{
    public class DepartmentController : ApiController
    {
        private DataDepartment data = new DataDepartment();

        [Route("getDepartmentList")]
        public List<Department> Get()
        {
            return data.getListDepartments();
        }
        [Route("getDepartmentListId")]
        public Department Get(int Id)
        {
            return data.getDepartmentId(Id);
        }
        [Route("addDepartment")]
        public HttpResponseMessage Post([FromBody]Department value)
        {
            if (data.AddDepartment(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
