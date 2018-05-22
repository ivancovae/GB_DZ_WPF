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
            EmployeeModel temp = _model as EmployeeModel;
            _employeeView.EmployeeName = temp.Employee.Name;
            _employeeView.EmployeeAge = temp.Employee.Age.ToString();
            _employeeView.EmployeeSalary = temp.Employee.Salary.ToString();
            _employeeView.EmployeeDepartment = temp.Employee.Department.Name;
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
