using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_WPF
{
    class DepartmentModel : IModel
    {
        private Department _department;
        public Department Department => _department;
        private string _departmentName;
        public string OldName => _oldName;
        private string _oldName;
        private WeakReference _owner = new WeakReference(null, false);

        public DepartmentModel(string departmentName)
        {
            _departmentName = departmentName;
        }

        public void LoadModel(IModel model)
        {
            if (model is CompanyModel)
            {
                CompanyModel temp = model as CompanyModel;
                _department = temp.Company.GetDepartment(_departmentName);
                _oldName = _departmentName;
                _owner = new WeakReference(temp, false);
            }
        }
        public void NewModel(IModel model)
        {
            if (model is CompanyModel)
            {
                CompanyModel temp = model as CompanyModel;
                Department department = new Department(_departmentName);
                temp.Company.AddNewDepartment(department);
                _department = department;
                _oldName = _departmentName;
                _owner = new WeakReference(temp, false);
            }
        }
        public List<string> GetDepartments()
        {
            return (_owner.Target as CompanyModel).Company.Departments;
        }

        public void SaveModel(IModel model)
        {
            (_owner.Target as CompanyModel).SaveModel(this);
        }

        public void Remove(string name)
        {
            _department.RemoveEmployee(name);
        }
    }
}
