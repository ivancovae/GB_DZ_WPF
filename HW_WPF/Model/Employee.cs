using System;

namespace HW_WPF
{
    /// <summary>
    /// Класс карточки сотрудника
    /// </summary>
    class Employee
    {
        #region Данные
        /// <summary>
        /// Свойство имени сотрудника
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Свойство возраста сотрудника
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Свойство зарплаты сотрудника
        /// </summary>
        public int Salary { get; set; }

        private WeakReference _department;
        /// <summary>
        /// Свойство департамента, в котором работает сотрудник,
        /// сотрудник может работать только в одном департаменте
        /// </summary>
        public Department Department => (_department.Target as Department);
        #endregion

        private Employee() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="salary">Зарплата</param>
        public Employee(string name, int age, int salary)
        {
            Name = name;
            Age = age;
            Salary = salary;            
            _department = new WeakReference(null, false);
        }
        /// <summary>
        /// Изменение департамента сотрудника, без изменения в департаменте
        /// </summary>
        /// <param name="newDepartment">Новый департамент</param>
        /// <returns>Старый департамент</returns>
        public Department ChangeDepartment(Department newDepartment)
        {
            var oldDepartment = Department;
            _department = new WeakReference(newDepartment, false);
            return oldDepartment;
        }
    }
}
