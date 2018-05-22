﻿using System;
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
        private string _employeeName;

        public EmployeeModel(string employeeName)
        {
            _employeeName = employeeName;
        }
        public void NewModel()
        {
            _employee = new Employee(_employeeName, 0, 0);
            _oldName = _employeeName;
        }

        public void LoadModel(IModel model)
        {
            if (model is DepartmentModel)
            {
                DepartmentModel temp = model as DepartmentModel;
                _employee = temp.Department.GetEmployee(_employeeName);
                _oldName = _employeeName;
            }
        }

        public void SaveModel(IModel model)
        {
            model.SaveModel(this);
        }
    }
}
