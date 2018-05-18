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
                Department.RenameDepartment(value);
                OnPropertyChanged("DepartmentName"); // уведомление View о том, что изменилась название департамента
            }
        }
        private ObservableCollection<string> _employees = new ObservableCollection<string>();
        private Dispatcher _dispatcher;

        /// <summary>
        /// Свойство списка сотрудников
        /// </summary>
        public ObservableCollection<string> Employees => _employees;
    }
}
