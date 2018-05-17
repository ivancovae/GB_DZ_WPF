using System;

namespace HW_WPF
{
    /// <summary>
    /// Класс карточки сотрудника
    /// </summary>
    class Employee
    {
        private Guid _guid;
        /// <summary>
        /// Свойство уникального идентификатора сотрудника
        /// </summary>
        public string ID => _guid.ToString();

        private string _name;
        /// <summary>
        /// Свойство имени сотрудника
        /// </summary>
        public string Name => _name.ToString();

        private string _surname;
        /// <summary>
        /// Свойство фамилии сотрудника
        /// </summary>
        public string SurName => _surname.ToString();
        private WeakReference _department;
        /// <summary>
        /// Свойство департамента, в котором работает сотрудник
        /// </summary>
        public Department Department => (_department.Target as Department);

        /// <summary>
        /// Конструктор создания карточки сотрудника
        /// </summary>
        /// <exception cref="ArgumentException">Исключение некорретного ввода Имени, Фамилии</exception>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        public Employee(string name, string surname)
        {
            if (surname == null || surname == "")
                throw new ArgumentException($"Фамилия не должна быть пустой", "surname");
            _surname = surname;

            if (name == null || name == "")
                throw new ArgumentException($"Имя не должно быть пустым", "name");
            _name = name;
            
            _department = new WeakReference(null, false);
            _guid = Guid.NewGuid();
        }

        /// <summary>
        /// Изменение департамента сотрудника
        /// </summary>
        /// <param name="newDepartment">Новый департамент</param>
        /// <returns></returns>
        public bool ChangeDepartment(Department newDepartment)
        {
            if (newDepartment == null)
                return false;
            _department = new WeakReference(newDepartment, false);
            return true;
        }
    }
}
