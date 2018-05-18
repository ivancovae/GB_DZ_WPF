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

        public EditEmployeeViewModel() : this( null ) { }

        public EditEmployeeViewModel(Dispatcher dispatcher = null)
        {
            _dispatcher = dispatcher ?? Dispatcher.CurrentDispatcher;
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
                return Employee.Name;
            }
            set
            {
                Employee.ChangeName(value);
                OnPropertyChanged("Name"); // уведомление View о том, что изменилась название департамента
            }
        }
        /// <summary>
        /// Свойство Имени
        /// </summary>
        public string EmployeeSurname
        {
            get
            {
                return Employee.SurName;
            }
            set
            {
                Employee.ChangeSurname(value);
                OnPropertyChanged("Surname"); // уведомление View о том, что изменилась название департамента
            }
        }

        /// <summary>
        /// Свойство модели для передачи в другую модель
        /// </summary>
        public Employee Employee { get; set; }
    }
}
