using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_WPF
{
    class EmployeeModel : IModel
    {
        private Employee _employee;
        public Employee Employee => _employee;
        public string OldName => _oldName;
        private string _oldName;
        private WeakReference _owner = new WeakReference(null, false);

        public EmployeeModel(string employeeName)
        {
            _oldName = employeeName;
        }
        public void NewModel(IModel model)
        {
            
            if (model is DepartmentModel)
            {
                DepartmentModel temp = model as DepartmentModel;
                _employee = new Employee(_oldName, 0, 0);
                temp.Department.AddNewEmployee(_employee);
                _owner = new WeakReference(temp, false);
            }
        }

        public void LoadModel(IModel model)
        {
            if (model is DepartmentModel)
            {
                DepartmentModel temp = model as DepartmentModel;
                _employee = temp.Department.GetEmployee(_oldName);
                _owner = new WeakReference(temp, false);
            }
        }

        public List<string> GetDepartments()
        {
            return (_owner.Target as DepartmentModel).GetDepartments();
        }

        public void SaveModel(IModel model)
        {
            (_owner.Target as DepartmentModel).SaveModel(this);
        }

        public void Remove(string name)
        {
            
        }
    }
}
