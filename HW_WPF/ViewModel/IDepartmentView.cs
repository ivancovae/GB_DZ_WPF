using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_WPF
{
    interface IDepartmentView
    {
        string DepartmentName { set; get; }
        List<string> Employees { get; set; }
        string SelectedEmployee { set; get; }
    }
}
