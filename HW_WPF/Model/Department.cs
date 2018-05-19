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
        private string _name;
        /// <summary>
        /// Свойство наименования департамента
        /// </summary>
        public string Name => _name.ToString();
        private List<Employee> _employees;
        /// <summary>
        /// Список сотрудников департамента
        /// </summary>
        public List<string> Employees => _employees.Select(e => (e.Name + " " + e.SurName)).ToList();
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
        /// Удаление сотрудника из департамента
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <returns>Успешность удаления true при успешном удаление, false при не возможности удаления сотрудника</returns>
        public bool RemoveEmployee(string employee)
        {
            var list = _employees.Select(e => e)
                                 .Where(e => employee == e.Name + " " + e.SurName).ToList();
            if (list.Count() == 0)
                return false;
            _employees.Remove(list.First());
            return true;
        }
        /// <summary>
        /// Проверка наличия сотрудника в департаменте
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <returns>Результат наличия сотрудника</returns>
        public bool CheckEmployee(Employee employee)
        {
            return _employees.Select(e => e)
                             .Where(e => ((e.Name == employee.Name) && (e.SurName == employee.SurName)))
                             .Count() > 0;
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
