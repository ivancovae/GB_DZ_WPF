using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_WPF
{
    class DepartmentPresenter : IPresenter
    {
        private IModel _model;
        private IDepartmentView _departmentView;
        private IPresenter _presenterEmployee;

        public DepartmentPresenter(IDepartmentView view, IModel model)
        {
            _departmentView = view;
            _model = model;
        }

        public void Hide()
        {
            
        }

        public void LoadData()
        {
            DepartmentModel temp = _model as DepartmentModel;
            _departmentView.DepartmentName = temp.Department.Name;
            _departmentView.Employees = temp.Department.Employees;
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
