using System;
using System.Collections.Generic;

namespace HW_WPF
{
    /// <summary>
    /// Класс модели работы с сущностью Карточка сотрудника
    /// </summary>
    class EmployeeModel : IModel
    {
        private Employee _employee;
        /// <summary>
        /// Свойство сотрудника
        /// </summary>
        public Employee Employee => _employee;
        /// <summary>
        /// Свойство имени сотрудника до изменений
        /// </summary>
        public string OldName => _oldName;
        private string _oldName;
        private WeakReference _owner = new WeakReference(null, false);
        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="employeeName">имя сотрудника</param>
        public EmployeeModel(string employeeName)
        {
            _oldName = employeeName;
        }
        /// <summary>
        /// Создание новой модели по сквозной связи
        /// </summary>
        /// <param name="model">родительская модель</param>
        public void NewModel(IModel model)
        {
            if (model is DepartmentModel)
            {
                DepartmentModel temp = model as DepartmentModel;
                _employee = new Employee(_oldName, 0, 0);
                while(!temp.Department.AddNewEmployee(_employee))
                {
                    _oldName = _oldName + "0";
                    _employee = new Employee(_oldName, 0, 0);
                }                    
                _owner = new WeakReference(temp, false);
            }
        }
        /// <summary>
        /// Реализация интерфейса по сквозной загрузке модели
        /// </summary>
        /// <param name="model">родительская модель</param>
        public void LoadModel(IModel model)
        {
            if (model is DepartmentModel)
            {
                DepartmentModel temp = model as DepartmentModel;
                _employee = temp.Department.GetEmployee(_oldName);
                _owner = new WeakReference(temp, false);
            }
        }
        /// <summary>
        /// Список департаментов по сквозной связи
        /// </summary>
        /// <returns>список департаментов</returns>
        public List<string> GetDepartments()
        {
            return (_owner.Target as DepartmentModel).GetDepartments();
        }
        /// <summary>
        /// Департамент по имени
        /// </summary>
        /// <returns>список департаментов</returns>
        public Department GetDepartment(string name)
        {
            return (_owner.Target as DepartmentModel).GetDepartment(name);
        }
        /// <summary>
        /// Реализация интерфейса по сквозному сохранению модели
        /// </summary>
        /// <param name="model">Модель "родительского" уровня или null</param>
        public void SaveModel(IModel model)
        {
            (_owner.Target as DepartmentModel).SaveModel(this);
        }
        /// <summary>
        /// Удаление записи в модели
        /// </summary>
        /// <param name="name">Имя записи</param>
        public void Remove(string name)
        {
            (_owner.Target as DepartmentModel).Remove(name);
        }
    }
}
