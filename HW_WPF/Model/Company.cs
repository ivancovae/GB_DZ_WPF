using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HW_WPF
{
    /// <summary>
    /// Класс карточки компании
    /// </summary>
    class Company : IEnumerable<Department>
    {
        #region Данные
        /// <summary>
        /// Свойство наименования компании
        /// </summary>
        public string Name { get; set; }
        private List<Department> _departments;
        /// <summary>
        /// Список департаментов компании
        /// </summary>
        public List<string> Departments => _departments.Select(e=>e.Name).ToList();
        #endregion

        private Company() {}
        /// <summary>
        /// Конструктор создания карточки компании
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="director">Директор</param>
        public Company(string name)
        {
            Name = name;
            _departments = new List<Department>();
        }
        /// <summary>
        /// Проверка наличия департамента
        /// </summary>
        /// <param name="department">Департамент</param>
        /// <returns>Результат проверки</returns>
        public bool CheckDepartment(Department department) => CheckDepartment(department.Name);
        /// <summary>
        /// Проверка наличия департамента
        /// </summary>
        /// <param name="name">Имя департамента</param>
        /// <returns>Результат проверки</returns>
        public bool CheckDepartment(string name) => _departments.Select(e => e)
                                                                .Where(e => (e.Name == name))
                                                                .Count() > 0;
        /// <summary>
        /// Добавление департамента
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <returns>Успешность добавления true при успешном добавление, false при уже существующем департаменте</returns>
        public bool AddNewDepartment(string name) => AddNewDepartment(new Department(name));
        /// <summary>
        /// Добавление департамента
        /// </summary>
        /// <param name="department">Департамент</param>
        /// <returns>Успешность добавления true при успешном добавление, false при уже существующем департаменте</returns>
        public bool AddNewDepartment(Department department)
        {
            if (CheckDepartment(department))
                return false;
            _departments.Add(department);
            return true;
        }
        /// <summary>
        /// Удаление департамента
        /// </summary>
        /// <param name="department">Департамент</param>
        /// <returns>Успешность удаления true при успешном удаление, false при не существующем департаменте</returns>
        public bool RemoveDepartment(Department department) => RemoveDepartment(department.Name);
        /// <summary>
        /// Удаление департамента
        /// </summary>
        /// <param name="department">Имя департамент</param>
        /// <returns>Успешность удаления true при успешном удаление, false при не существующем департаменте</returns>
        public bool RemoveDepartment(string department)
        {
            var list = _departments.Select(e => e)
                                   .Where(e => e.Name == department)
                                   .ToList();
            if (list.Count == 0)
                return false;
            _departments.Remove(list.First());
            return true;
        }
        /// <summary>
        /// Получить объект департамента
        /// </summary>
        /// <param name="name">Имя департамента</param>
        /// <returns>Объект департамента</returns>
        public Department GetDepartment(string name)
        {
            var list = _departments.Select(e => e)
                                   .Where(e => e.Name == name);
            if (list.Count() == 0)
                return null;
            return list.First();
        }
        /// <summary>
        /// Обновление департамента, через полное обновление объекта, удаление и последующее добавление нового, измененного объекта
        /// </summary>
        /// <param name="department">департамент с изменениями</param>
        /// <returns>успешность замены, true если успех, false если депортамента нет</returns>
        public bool UpdateDepartment(string oldName, Department department)
        {
            var list = _departments.Select(e => e)
                                   .Where(e => e.Name == oldName).ToList();
            if (list.Count == 0)
                return false;

            _departments.Remove(list.First());
            _departments.Add(department);
            return true;
        }

        public IEnumerator<Department> GetEnumerator()
        {
            foreach (var department in _departments)
            {
                yield return department as Department;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Department>)_departments).GetEnumerator();
        }
    }
}
