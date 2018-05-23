using System;
using System.Xml.Linq;
using System.IO;

namespace HW_WPF
{
    class CompanyModel : IModel
    {
        private Company _company;
        public Company Company => _company;
        private readonly string _fileName;
        public CompanyModel(string fileName = "base.db")
        {
            _fileName = fileName;
        }

        public void LoadData()
        {
            using (StreamReader reader = File.OpenText(_fileName))
            {
                string streamContents = reader.ReadToEnd();
                XDocument xDoc = XDocument.Parse(streamContents);
                XElement xCompany = xDoc.Element("Company");
                XAttribute nameCompany = xCompany.Attribute("Name");
                _company = new Company(nameCompany.Value);

                foreach (XElement xDepartment in xCompany.Elements("Department"))
                {
                    XAttribute nameDepartment = xDepartment.Attribute("Name");
                    Department department = new Department(nameDepartment.Value);
                    foreach (XElement xEmployee in xDepartment.Elements("Employee"))
                    {
                        XAttribute nameEmployee = xEmployee.Attribute("Name");
                        XAttribute ageEmployee = xEmployee.Attribute("Age");
                        XAttribute salaryEmployee = xEmployee.Attribute("Salary");
                        Employee employee = new Employee(nameEmployee.Value, Convert.ToInt32(ageEmployee.Value), Convert.ToInt32(salaryEmployee.Value));
                        department.AddNewEmployee(employee);
                    }
                    _company.AddNewDepartment(department);
                }
            }
        }

        public void SaveData()
        {
            XDocument xDoc = new XDocument();
            XElement xCompany = new XElement("Company");
            XAttribute xCompanyNameAttr = new XAttribute("Name", _company.Name);
            xCompany.Add(xCompanyNameAttr);

            foreach (var department in _company)
            {
                XElement xDepartment = new XElement("Department");
                XAttribute xDepartmentNameAttr = new XAttribute("Name", department.Name);
                xDepartment.Add(xDepartmentNameAttr);
                foreach (var employee in department)
                {
                    XElement xEmployee = new XElement("Employee");
                    XAttribute xEmployeeNameAttr = new XAttribute("Name", employee.Name);
                    XAttribute xEmployeeAgeAttr = new XAttribute("Age", employee.Age.ToString());
                    XAttribute xEmployeeSalaryAttr = new XAttribute("Salary", employee.Salary.ToString());
                    xEmployee.Add(xEmployeeNameAttr);
                    xEmployee.Add(xEmployeeAgeAttr);
                    xEmployee.Add(xEmployeeSalaryAttr);
                    xDepartment.Add(xEmployee);
                }
                xCompany.Add(xDepartment);
            }
            xDoc.Add(xCompany);
            xDoc.Save(_fileName);                        
        }

        public void SaveModel(IModel model)
        {
            SaveData();
        }

        public void LoadModel(IModel model)
        {
            LoadData();
        }

        public void Remove(string name)
        {
            _company.RemoveDepartment(name);
        }
    }
}
