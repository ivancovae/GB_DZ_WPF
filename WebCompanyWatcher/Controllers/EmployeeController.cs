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
    /// Контроллер получения данных о сотрудниках
    /// </summary>
    public class EmployeeController : ApiController
    {
        private DataEmployee data = new DataEmployee();

        /// <summary>
        /// Метод API для получения списка всех сотрудников
        /// </summary>
        /// <returns>список сотрудников</returns>
        [Route("getEmployeeList")]
        public List<Employee> Get()
        {
            return data.getListEmployees();
        }
        /// <summary>
        /// Метод API для получения списка сотрудников в департаменте
        /// </summary>
        /// <param name="Id">уникальный номер департамента</param>
        /// <returns>список сотрудников</returns>
        [Route("getEmployeeListForDepartment/{Id}")]
        public List<Employee> GetEmployees(int Id)
        {
            return data.getListEmployeisForDepartment(Id);
        }
        /// <summary>
        /// Метод API для получения сотрудника
        /// </summary>
        /// <param name="Id">уникальный номер сотрудника</param>
        /// <returns>объект сотрудника</returns>
        [Route("getEmployeeId/{Id}")]
        public Employee Get(int Id)
        {
            return data.getEmployeeId(Id);
        }
    }
}
