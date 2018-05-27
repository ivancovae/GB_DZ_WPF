using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebCompanyWatcher.Models;

namespace WebCompanyWatcher.Controllers
{
    public class CompanyController : ApiController
    {
        private DataCompany data = new DataCompany();

        [Route("getCompanyList")]
        public List<Company> Get()
        {
            return data.getListCompanies();
        }
        [Route("getCompanyListId")]
        public Company Get(int Id)
        {
            return data.getCompanyId(Id);
        }
        [Route("addCompany")]
        public HttpResponseMessage Post([FromBody]Company value)
        {
            if (data.AddCompany(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
