using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace HW_WPF
{
    /// <summary>
    /// Класс View-Model уровня
    /// </summary>
    class EditDeportmentViewModel : INotifyPropertyChanged
    {
        private Dispatcher _dispatcher;
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public EditDeportmentViewModel() : this( null ) { }
        /// <summary>
        /// Конструктор с передачей службы для управления очередью рабочих элементов для потока
        /// </summary>
        public EditDeportmentViewModel(Dispatcher dispatcher = null)
        {
            _dispatcher = dispatcher ?? Dispatcher.CurrentDispatcher;
        }
        /// <summary>
        /// Событие изменения свойств
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Свойство модели для передачи в другую модель
        /// </summary>
        public Department Department
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
                OnPropertyChanged("Employees"); // уведомление View о том, что изменилась название компании
            }
        }
        private Department _department = null;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Свойство наименования департамента
        /// </summary>
        public string DepartmentName
        {
            get
            {
                return _department?.Name ?? "";
            }
            set
            {
                _department?.RenameDepartment(value);
                OnPropertyChanged("DepartmentName"); // уведомление View о том, что изменилась название департамента
            }
        }
        private ObservableCollection<string> _employees = new ObservableCollection<string>();
        /// <summary>
        /// Свойство списка сотрудников
        /// </summary>
        public ObservableCollection<string> Employees => new ObservableCollection<string>(_department.Employees);

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="employee">объект сотрудника</param>
        /// <returns>успешность добавления сотрудника</returns>
        public bool AddEmployee(Employee employee)
        {
            if (_department.AddNewEmployee(employee))
            {
                OnPropertyChanged("Employees");
                return true;
            }

            return false;
        }
        /// <summary>
        /// Удаление сотрудника по имени из списка
        /// </summary>
        /// <param name="employee">имя сотрудника Имя + Фамилия</param>
        /// <returns>успешность удаления сотрудника</returns>
        public bool RemoveEmployee(string employee)
        {
            if (_department.RemoveEmployee(employee))
            {
                OnPropertyChanged("Employees");
                return true;
            }
            return false;
        }
        /// <summary>
        /// получение объекта сотрудника по имени из списка
        /// </summary>
        /// <param name="name">имя сотрудника из списка</param>
        /// <returns>объект сотрудника</returns>
        public Employee GetEmployee(string name)
        {
            return _department.GetEmployee(name);
        }
        /// <summary>
        /// Обновление Сотрудников с передачей текущего измененного
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        public void UpdateEmployees(Employee employee)
        {
            OnPropertyChanged("Employees");
        }
    }
}
