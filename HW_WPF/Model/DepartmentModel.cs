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

        public DepartmentModel(string departmentName)
        {
            _departmentName = departmentName;
        }

        public void LoadModel(IModel model)
        {
            if(model is CompanyModel)
            {
                CompanyModel temp = model as CompanyModel;
                _department = temp.Company.GetDepartment(_departmentName);
                _oldName = _departmentName;
            }
        }
        public void NewModel()
        {
            _department = new Department(_departmentName);
            _oldName = _departmentName;
        }

        public void SaveModel(IModel model)
        {
            if (model is EmployeeModel)
            {
                EmployeeModel md = model as EmployeeModel;
                var name = md.Employee.Name;
                _department.UpdateEmployee(md.OldName, md.Employee);
                model.SaveModel(this);
            }
        }
    }
}
