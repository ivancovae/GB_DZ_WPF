using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace HW_WPF
{
    /// <summary>
    /// Класс View-Model уровня
    /// </summary>
    class EditDeportmentViewModel : INotifyPropertyChanged
    {
        private readonly Department _model = new Department();
        /// <summary>
        /// Событие изменения свойств
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        /// <summary>
        /// Свойство наименования компании
        /// </summary>
        public string DepartmentName
        {
            get
            {
                return _model.Name;
            }
            set
            {
                _model.RenameDepartment(value);
                OnPropertyChanged("DepartmentName"); // уведомление View о том, что изменилась название департамента
            }
        }
        private ObservableCollection<string> _employees = new ObservableCollection<string>();
        /// <summary>
        /// Свойство списка сотрудников
        /// </summary>
        public ObservableCollection<string> Employees => _employees;

        /// <summary>
        /// Свойство модели для передачи в другую модель
        /// </summary>
        public Department Department => _model;
    }
}
