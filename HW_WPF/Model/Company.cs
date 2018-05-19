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
        private string _name;
        /// <summary>
        /// Свойство наименования компании
        /// </summary>
        public string Name => _name.ToString();
        private List<Department> _departments;
        /// <summary>
        /// Список департаментов компании
        /// </summary>
        public List<string> Departments => _departments.Select(e=>e.Name).ToList();
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
            if (Departments.IndexOf(name) != -1)
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
            if (Departments.IndexOf(department.Name) != -1)
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
        /// <summary>
        /// Удаление департамента
        /// </summary>
        /// <param name="department">Департамент</param>
        /// <returns>Успешность удаления true при успешном удаление, false при не существующем департаменте</returns>
        public bool RemoveDepartment(Department department)
        {
            if (Departments.IndexOf(department.Name) == -1)
                return false;
            _departments.Remove(department);
            return true;
        }
        /// <summary>
        /// Удаление департамента
        /// </summary>
        /// <param name="department">Имя департамент</param>
        /// <returns>Успешность удаления true при успешном удаление, false при не существующем департаменте</returns>
        public bool RemoveDepartment(string department)
        {
            var list = _departments.Select(e => e)
                                   .Where(e => e.Name == department).ToList();
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
        public bool UpdateDepartment(Department department)
        {
            var list = _departments.Select(e => e)
                                   .Where(e => e.Name == department.Name).ToList();
            if (list.Count == 0)
                return false;

            _departments.Remove(list.First());
            _departments.Add(department);
            return true;
        }
    }
}
