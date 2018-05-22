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

        public DepartmentPresenter(IDepartmentView view, IModel model)
        {
            _departmentView = view;
            _model = model;
        }
        private void OpenEditWindow(EmployeeModel em)
        {
            EditEmpoyee editEmployeeWindow = new EditEmpoyee(em);
            var result = editEmployeeWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                em.SaveModel(_model);
            }
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
            DepartmentModel temp = _model as DepartmentModel;
            temp.Department.Name = _departmentView.DepartmentName;
        }

        public void Show()
        {
            EmployeeModel em = new EmployeeModel(_departmentView.SelectedEmployee);
            em.NewModel();
            OpenEditWindow(em);
        }

        public void Remove()
        {
            
        }

        public void Edit()
        {
            EmployeeModel em = new EmployeeModel(_departmentView.SelectedEmployee);
            em.LoadModel(_model);
            OpenEditWindow(em);
        }
    }
}
