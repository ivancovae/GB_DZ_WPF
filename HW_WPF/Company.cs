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

        private Employee _director;
        /// <summary>
        /// Свойство директора компании
        /// </summary>
        public Employee Director => _director;

        private List<Department> _departments;
        

        /// <summary>
        /// Конструктор создания карточки компании
        /// </summary>
        /// <exception cref="ArgumentException">Исключение некорретного ввода Наименования, Директора</exception>
        /// <param name="name">Наименование</param>
        /// <param name="director">Директор</param>
        public Company(string name, Employee director)
        {
            if (name == null || name == "")
                throw new ArgumentException($"Имя не должно быть пустым", "name");
            _name = name;
            if (director == null)
                throw new ArgumentException($"Для компании должен быть задан директор", "director");
            _director = director;
            _departments = new List<Department>();
            _guid = Guid.NewGuid();
        }

        public bool AddNewDepartment(string name, Employee director)
        {
            var department = new Department(name, director);
            if (_departments.IndexOf(department) != -1)
                return false;
            _departments.Add(department);
            return true;
        }
    }
}
