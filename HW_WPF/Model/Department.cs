using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HW_WPF
{
    /// <summary>
    /// Класс карточки департамента
    /// </summary>
    class Department : IEnumerable<Employee>
    {
        #region Данные
        /// <summary>
        /// Свойство наименования департамента
        /// </summary>
        public string Name { set; get; }
        private List<Employee> _employees;
        /// <summary>
        /// Список сотрудников департамента
        /// </summary>
        public List<string> Employees => _employees.Select(e => (e.Name)).ToList();
        #endregion

        private Department() { }
        /// <summary>
        /// Конструктор создания карточки департамента
        /// </summary>
        /// <param name="name">Наименование</param>
        public Department(string name)
        {
            Name = name;
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
        public bool RemoveEmployee(Employee employee) => RemoveEmployee(employee.Name);
        /// <summary>
        /// Удаление сотрудника из департамента
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <returns>Успешность удаления true при успешном удаление, false при не возможности удаления сотрудника</returns>
        public bool RemoveEmployee(string employee)
        {
            var list = _employees.Select(e => e)
                                 .Where(e => employee == e.Name).ToList();
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
        public bool CheckEmployee(Employee employee) => _employees.Select(e => e)
                                                                  .Where(e => (e.Name == employee.Name))
                                                                  .Count() > 0;
        /// <summary>
        /// Возврат Сотрудника по имени из списка
        /// </summary>
        /// <param name="name">Сотрудник</param>
        /// <returns>сотрудник, если он есть в списке департамента</returns>
        public Employee GetEmployee(string name)
        {
            var list = _employees.Select(e => e)
                                 .Where(e => (e.Name == name));
            if (list.Count() == 0)
                return null;
            return list.First();
        }
        public bool UpdateEmployee(string oldName, Employee employee)
        {
            var list = _employees.Select(e => e)
                                   .Where(e => e.Name == oldName).ToList();
            if (list.Count == 0)
                return false;

            _employees.Remove(list.First());
            _employees.Add(employee);
            return true;
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            foreach(var employee in _employees)
            {
                yield return employee as Employee;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Employee>)_employees).GetEnumerator();
        }
    }
}
