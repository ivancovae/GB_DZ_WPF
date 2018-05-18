using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_WPF
{
    /// <summary>
    /// Класс карточки компании
    /// </summary>
    class Company
    {
        private Guid _guid;
        /// <summary>
        /// Свойство уникального идентификатора компании
        /// </summary>
        public string ID => _guid.ToString();

        private string _name;
        /// <summary>
        /// Свойство наименования компании
        /// </summary>
        public string Name => _name.ToString();
        
        private List<Department> _departments;

        /// <summary>
        /// Список департаментов компании
        /// </summary>
        public string[] Departments => _departments.Select(e=>e.Name).ToArray();


        /// <summary>
        /// Конструктор по умолчанию задает Без названия
        /// </summary>
        public Company() : this("Без названия") {}

        /// <summary>
        /// Конструктор создания карточки компании
        /// </summary>
        /// <exception cref="ArgumentException">Исключение некорретного ввода Наименования</exception>
        /// <param name="name">Наименование</param>
        /// <param name="director">Директор</param>
        public Company(string name)
        {
            if (name == null || name == "")
                throw new ArgumentException($"Имя не должно быть пустым", "name");
            _name = name;

            _departments = new List<Department>();
            _guid = Guid.NewGuid();
        }

        /// <summary>
        /// Добавление департамента
        /// </summary>
        /// <exception cref="ArgumentException">Исключение некорретного ввода Наименования</exception>
        /// <param name="name">Наименование</param>
        /// <returns>Успешность добавления true при успешном добавление, false при уже существующем департаменте</returns>
        public bool AddNewDepartment(string name)
        {
            var department = new Department(name);
            if (_departments.IndexOf(department) != -1)
                return false;
            _departments.Add(department);
            return true;
        }
        /// <summary>
        /// Добавление департамента
        /// </summary>
        /// <param name="department">Департамент</param>
        /// <returns>Успешность добавления true при успешном добавление, false при уже существующем департаменте</returns>
        public bool AddNewDepartment(Department department)
        {
            var list = _departments.Select(e => e.Name).ToList();
            if (list.IndexOf(department.Name) != -1)
                return false;
            _departments.Add(department);
            return true;
        }
        /// <summary>
        /// Переименование фирмы
        /// </summary>
        /// <param name="newName">Новое имя</param>
        public void RenameCompany(string newName)
        {
            _name = newName;
        }
    }
}
