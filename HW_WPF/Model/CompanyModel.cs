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
            StreamReader reader = File.OpenText(_fileName);
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

        public void SaveData()
        {
            XDocument xDoc = XDocument.Load(_fileName);
            XElement xCompany = xDoc.Element("Company");
            xCompany.Attribute("Name").Value = _company.Name;

            foreach (XElement xDepartment in xCompany.Elements())
            {
                var department = _company.GetDepartment(xDepartment.Attribute("Name").Value);
                xDepartment.Attribute("Name").Value = department.Name;
                foreach (XElement xEmployee in xDepartment.Elements())
                {
                    var employee = department.GetEmployee(xEmployee.Attribute("Name").Value);
                    xEmployee.Attribute("Name").Value = employee.Name;
                    xEmployee.Attribute("Age").Value = employee.Age.ToString();
                    xEmployee.Attribute("Salary").Value = employee.Salary.ToString();
                    xEmployee.Attribute("Department").Value = employee.Department.Name;
                }
            }
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
    }
}
