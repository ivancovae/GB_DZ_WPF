using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_WPF
{
    class EmployeePresenter : IPresenter
    {
        private IModel _model;
        private IEmployeeView _employeeView;
        public EmployeePresenter(IEmployeeView view, IModel model)
        {
            _employeeView = view;
            _model = model;
        }
        public void Hide()
        {
            
        }

        public void LoadData()
        {
            
        }

        public void SaveData()
        {
            
        }

        public void Show()
        {
            
        }

        public void Remove()
        {
            
        }

        public void Edit()
        {
            
        }
    }
}
