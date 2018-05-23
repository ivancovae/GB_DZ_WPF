using System.Collections.Generic;

namespace HW_WPF
{
    /// <summary>
    /// Интерфейс представления сотрудника
    /// </summary>
    interface IEmployeeView
    {
        /// <summary>
        /// свойство имени сотрудника
        /// </summary>
        string EmployeeName { set; get; }
        /// <summary>
        /// свойство возраста сотрудника
        /// </summary>
        string EmployeeAge { set; get; }
        /// <summary>
        /// свойство зарплаты сотрудника
        /// </summary>
        string EmployeeSalary { set; get; }
        /// <summary>
        /// свойство департаментов сотрудника, для выбора
        /// </summary>
        List<string> Deportments { set; get; }
        /// <summary>
        /// свойство департамента сотрудника, выбранного
        /// </summary>
        string EmployeeDepartment { set; get; }
    }
}
