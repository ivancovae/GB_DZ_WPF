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
    /// Контроллер получения данных о департаментах
    /// </summary>
    public class DepartmentController : ApiController
    {
        private DataDepartment data = new DataDepartment();

        /// <summary>
        /// Метод API для получения списка всех департаментов
        /// </summary>
        /// <returns>список департаментов</returns>
        [Route("getDepartmentList")]
        public List<Department> Get()
        {
            return data.getListDepartments();
        }
        /// <summary>
        /// Метод API для получения департамента в компании
        /// </summary>
        /// <param name="Id">уникальный номер компании</param>
        /// <returns>список департаментов</returns>
        [Route("getDepartmentsListForCompany/{Id}")]
        public List<Department> GetDepartments(int Id)
        {
            return data.getListDepartmentsForCompany(Id);
        }
        /// <summary>
        /// Метод API для получения департамента
        /// </summary>
        /// <param name="Id">уникальный номер департамента</param>
        /// <returns>объект департамента</returns>
        [Route("getDepartmentId/{Id}")]
        public Department Get(int Id)
        {
            return data.getDepartmentId(Id);
        }
    }
}
