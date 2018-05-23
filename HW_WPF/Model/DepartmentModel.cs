using System;
using System.Collections.Generic;

namespace HW_WPF
{
    /// <summary>
    /// Класс модели работы с сущностью Карточка департамента
    /// </summary>
    class DepartmentModel : IModel
    {
        private Department _department;
        /// <summary>
        /// Свойство департамента
        /// </summary>
        public Department Department => _department;
        private string _departmentName;
        /// <summary>
        /// Свойство имени департамента до изменений
        /// </summary>
        public string OldName => _oldName;
        private string _oldName;
        private WeakReference _owner = new WeakReference(null, false);
        /// <summary>
        /// Конструктор с параметром имени
        /// </summary>
        /// <param name="departmentName">имя департамента</param>
        public DepartmentModel(string departmentName)
        {
            _departmentName = departmentName;
        }
        /// <summary>
        /// Реализация интерфейса по сквозной загрузке модели
        /// </summary>
        /// <param name="model">Модель "родительского" уровня</param>
        public void LoadModel(IModel model)
        {
            if (model is CompanyModel)
            {
                CompanyModel temp = model as CompanyModel;
                _department = temp.Company.GetDepartment(_departmentName);
                _oldName = _departmentName;
                _owner = new WeakReference(temp, false);
            }
        }
        /// <summary>
        /// Создание новой модели по сквозной связи
        /// </summary>
        /// <param name="model">Модель "родительского" уровня</param>
        public void NewModel(IModel model)
        {
            if (model is CompanyModel)
            {
                CompanyModel temp = model as CompanyModel;
                Department department = new Department(_departmentName);
                _oldName = _departmentName;
                while (!temp.Company.AddNewDepartment(department))
                {
                    _oldName = _oldName + "0";
                    _departmentName = _oldName;
                    department = new Department(_departmentName);
                }
                _department = department;
                _owner = new WeakReference(temp, false);
            }
        }
        /// <summary>
        /// Список департаментов по сквозной связи
        /// </summary>
        /// <returns>список департаментов</returns>
        public List<string> GetDepartments()
        {
            return (_owner.Target as CompanyModel).Company.Departments;
        }
        /// <summary>
        /// Реализация интерфейса по сквозному сохранению модели
        /// </summary>
        /// <param name="model">Модель "родительского" уровня или null</param>
        public void SaveModel(IModel model)
        {
            (_owner.Target as CompanyModel).SaveModel(this);
        }
        /// <summary>
        /// Удаление записи в модели
        /// </summary>
        /// <param name="name">Имя записи</param>
        public void Remove(string name)
        {
            _department.RemoveEmployee(name);
        }
        /// <summary>
        /// Департамент по имени
        /// </summary>
        /// <returns>список департаментов</returns>
        public Department GetDepartment(string name)
        {
            return (_owner.Target as CompanyModel).Company.GetDepartment(name);
        }
    }
}
