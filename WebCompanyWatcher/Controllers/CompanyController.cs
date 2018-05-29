using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebCompanyWatcher.Models;

namespace WebCompanyWatcher.Controllers
{
    /// <summary>
    /// Контроллер получения данных о компаниях
    /// </summary>
    public class CompanyController : ApiController
    {
        private DataCompany data = new DataCompany();

        /// <summary>
        /// Метод API для получения списка компаний
        /// </summary>
        /// <returns>Список компаний</returns>
        [Route("getCompanyList")]
        public List<Company> Get()
        {
            return data.getListCompanies();
        }
        /// <summary>
        /// Метод API для получения компании
        /// </summary>
        /// <param name="Id">уникальный номер компании</param>
        /// <returns>объект компании</returns>
        [Route("getCompanyListId/{Id}")]
        public Company Get(int Id)
        {
            return data.getCompanyId(Id);
        }
    }
}
