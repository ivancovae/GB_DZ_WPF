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
        [Route("getDepartmentsListForCompany/{Id}")]
        public List<Department> GetDepartments(int Id)
        {
            return data.getListDepartmentsForCompany(Id);
        }
        [Route("getDepartmentListId/{Id}")]
        public Department Get(int Id)
        {
            return data.getDepartmentId(Id);
        }
    }
}
