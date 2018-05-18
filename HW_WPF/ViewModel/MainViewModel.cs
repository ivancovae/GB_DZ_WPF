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
    class MainViewModel : INotifyPropertyChanged
    {
        private readonly Company _model = new Company();
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
        public string CompanyName
        {
            get
            {
                return _model.Name;
            }
            set
            {
                _model.RenameCompany(value);
                OnPropertyChanged("CompanyName"); // уведомление View о том, что изменилась название компании
            }
        }
        /// <summary>
        /// Свойство списка департаментов
        /// </summary>
        public ObservableCollection<string> Deportments => new ObservableCollection<string>(_model.Departments);

        /// <summary>
        /// Добавление департамента в модель из вне. Пока что не придумал на скорую руку другой подход. to do
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public bool AddDepartment(Department department)
        {
            if(_model.AddNewDepartment(department))
            {
                OnPropertyChanged("Deportments");
                return true;
            }

            return false;
        }
    }
}
