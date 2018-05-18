using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_WPF
{
    /// <summary>
    /// Класс карточки департамента
    /// </summary>
    class Department
    {
        private Guid _guid;
        /// <summary>
        /// Свойство уникального идентификатора департамента
        /// </summary>
        public string ID => _guid.ToString();

        private string _name;
        /// <summary>
        /// Свойство наименования департамента
        /// </summary>
        public string Name => _name.ToString();

        private List<Employee> _employees;

        /// <summary>
        /// Конструктор по умолчанию задает Без названия
        /// </summary>
        public Department() : this("Без названия") { }

        /// <summary>
        /// Конструктор создания карточки департамента
        /// </summary>
        /// <exception cref="ArgumentException">Исключение некорретного ввода Наименования</exception>
        /// <param name="name">Наименование</param>
        public Department(string name)
        {
            if (name == null || name == "")
                throw new ArgumentException($"Имя не должно быть пустым", "name");
            _name = name;
            
            _employees = new List<Employee>();
            _guid = Guid.NewGuid();
        }

        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <returns>Успешность добавления true при успешном добавление, false при уже существующем сотруднике</returns>
        public bool AddNewEmployee(Employee employee)
        {
            if (CheckEmployee(employee))
                return false;
            _employees.Add(employee);
            employee.ChangeDepartment(this);
            return true;
        }

        /// <summary>
        /// Удаление сотрудника из департамента
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <returns>Успешность удаления true при успешном удаление, false при не возможности удаления сотрудника</returns>
        public bool RemoveEmployee(Employee employee)
        {
            if (!CheckEmployee(employee))
                return false;
            _employees.Remove(employee);
            employee.ChangeDepartment(null);
            return true;
        }

        /// <summary>
        /// Проверка наличия сотрудника в департаменте
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <returns>Результат наличия сотрудника</returns>
        public bool CheckEmployee(Employee employee)
        {
            return _employees.IndexOf(employee) != -1;
        }

        /// <summary>
        /// Переименование департамента
        /// </summary>
        /// <param name="newName">Новое имя</param>
        public void RenameDepartment(string newName)
        {
            _name = newName;
        }
    }
}
