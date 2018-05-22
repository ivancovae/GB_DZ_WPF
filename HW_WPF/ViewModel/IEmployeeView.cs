using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_WPF
{
    interface IEmployeeView
    {
        string EmployeeName { set; get; }
        string EmployeeAge { set; get; }
        string EmployeeSalary { set; get; }
        List<string> Deportments { set; get; }
        string EmployeeDepartment { set; get; }
    }
}
