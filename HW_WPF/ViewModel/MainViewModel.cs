using System;
using System.Windows;
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
        private Company _company = Application.Current.Resources["Company"] as Company;
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
                return _company.Name;
            }
            set
            {
                _company.RenameCompany(value);
                OnPropertyChanged("CompanyName"); // уведомление View о том, что изменилась название компании
            }
        }
        /// <summary>
        /// Свойство списка департаментов
        /// </summary>
        public ObservableCollection<string> Deportments => new ObservableCollection<string>(_company.Departments);

        /// <summary>
        /// Добавление департамента в модель из вне. Пока что не придумал на скорую руку другой подход. to do
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public bool AddDepartment(Department department)
        {
            if(_company.AddNewDepartment(department))
            {
                OnPropertyChanged("Deportments");
                return true;
            }

            return false;
        }

        public bool RemoveDepartment(string department)
        {
            if (_company.RemoveDepartment(department))
            {
                OnPropertyChanged("Deportments");
                return true;
            }
            return false;
        }

        public Department GetDepartment(string name)
        {
            return _company.GetDepartment(name);
        }

        public void UpdateDepartments()
        {
            OnPropertyChanged("Deportments");
        }
    }
}
