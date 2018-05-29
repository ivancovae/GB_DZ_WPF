using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCompanyWatcher.Models
{
    /// <summary>
    /// Класс объекта Сотрудника
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Свойство Уникальный номер
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Свойство Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Свойство Возраст
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Свойство Зарплата
        /// </summary>
        public int Salary { get; set; }
    }
}