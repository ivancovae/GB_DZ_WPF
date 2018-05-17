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

        private Employee _director;
        /// <summary>
        /// Свойство директора департамента
        /// </summary>
        public Employee Director => _director;

        private List<Employee> _employees;

        /// <summary>
        /// Конструктор создания карточки департамента
        /// </summary>
        /// <exception cref="ArgumentException">Исключение некорретного ввода Наименования, Директора</exception>
        /// <param name="name">Наименование</param>
        /// <param name="director">Директор</param>
        public Department(string name, Employee director)
        {
            if (name == null || name == "")
                throw new ArgumentException($"Имя не должно быть пустым", "name");
            _name = name;
            if (director == null)
                throw new ArgumentException($"Для департамента должен быть задан директор", "director");
            _director = director;
            _employees = new List<Employee>();
            _employees.Add(director);
            _guid = Guid.NewGuid();
        }
    }
}
