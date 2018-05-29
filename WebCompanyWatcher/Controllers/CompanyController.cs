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
        [Route("getCompanyListId/{Id}")]
        public Company Get(int Id)
        {
            return data.getCompanyId(Id);
        }
    }
}
