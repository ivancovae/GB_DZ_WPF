using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCompanyWatcher.Models
{
    /// <summary>
    /// Класс объекта Компании
    /// </summary>
    public class Company
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