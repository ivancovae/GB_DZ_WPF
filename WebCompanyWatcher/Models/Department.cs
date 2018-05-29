using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCompanyWatcher.Models
{
    /// <summary>
    /// Класс объекта Департамента
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Свойство Уникальный номер
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Свойство Имя
        /// </summary>
        public string Name { get; set; }
    }
}