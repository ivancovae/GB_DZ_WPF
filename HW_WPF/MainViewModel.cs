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
        private ObservableCollection<string> _deportments = new ObservableCollection<string>();
        /// <summary>
        /// Свойство списка департаментов
        /// </summary>
        public ObservableCollection<string> Deportments => _deportments;
    }
}
