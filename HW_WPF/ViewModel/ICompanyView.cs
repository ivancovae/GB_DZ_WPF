using System.Collections.Generic;

namespace HW_WPF
{
    interface ICompanyView
    {
        string CompanyName { set; get; }
        List<string> Departments { get; set; }
        string SelectedDepartment { set; get; }
    }
}
