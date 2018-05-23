using System.Collections.Generic;

namespace HW_WPF
{
    /// <summary>
    /// Интерфейс представления компании
    /// </summary>
    interface ICompanyView
    {
        /// <summary>
        /// Свойство имени компании
        /// </summary>
        string CompanyName { set; get; }
        /// <summary>
        /// Свойство списка департаментов
        /// </summary>
        List<string> Departments { get; set; }
        /// <summary>
        /// Свойство выбранного департамента
        /// </summary>
        string SelectedDepartment { set; get; }
    }
}
