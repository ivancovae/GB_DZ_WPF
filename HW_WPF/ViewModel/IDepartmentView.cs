using System.Collections.Generic;

namespace HW_WPF
{
    /// <summary>
    /// Интерфейс представления департамента
    /// </summary>
    interface IDepartmentView
    {
        /// <summary>
        /// Свойство имени департамента
        /// </summary>
        string DepartmentName { set; get; }
        /// <summary>
        /// Свойство списка сотрцдников
        /// </summary>
        List<string> Employees { get; set; }
        /// <summary>
        /// Свойство выбранного сотрудника
        /// </summary>
        string SelectedEmployee { set; get; }
    }
}
