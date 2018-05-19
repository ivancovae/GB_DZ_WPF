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
    class EditEmployeeViewModel : INotifyPropertyChanged
    {
        private Dispatcher _dispatcher;
        private Employee _employee;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public EditEmployeeViewModel() : this( null ) { }
        /// <summary>
        /// Конструктор с передачей службы для управления очередью рабочих элементов для потока
        /// </summary>
        public EditEmployeeViewModel(Dispatcher dispatcher = null)
        {
            _dispatcher = dispatcher ?? Dispatcher.CurrentDispatcher;
            _employee = new Employee("Без имени", "Без фамилии");
        }
        /// <summary>
        /// Событие изменения свойств
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Свойство Имени
        /// </summary>
        public string EmployeeName
        {
            get
            {
                return _employee.Name;
            }
            set
            {
                _employee.ChangeName(value);
                OnPropertyChanged("EmployeeName"); // уведомление View о том, что изменилась название департамента
            }
        }
        /// <summary>
        /// Свойство Имени
        /// </summary>
        public string EmployeeSurname
        {
            get
            {
                return _employee.SurName;
            }
            set
            {
                _employee.ChangeSurname(value);
                OnPropertyChanged("EmployeeSurname"); // уведомление View о том, что изменилась название департамента
            }
        }

        /// <summary>
        /// Свойство департамента
        /// </summary>
        public string EmployeeDepartment
        {
            get
            {
                return _employee.Department.Name;
            }
            set
            {
                _employee.ChangeDepartment((App.Current.Resources["Company"] as Company).GetDepartment(value));
                OnPropertyChanged("EmployeeDepartment"); // уведомление View о том, что изменилась название департамента
            }
        }

        /// <summary>
        /// Свойство модели для передачи в другую модель
        /// </summary>
        public Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
                EmployeeDepartment = _employee.Department.Name;                
                OnPropertyChanged("EmployeeName");
                OnPropertyChanged("EmployeeSurname");
                
            }
        }
    }
}
