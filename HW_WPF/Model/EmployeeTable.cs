using System.Runtime.Serialization;

namespace HW_WPF.Model
{
    [DataContract]
    public class EmployeeTable
    {
        [DataMember]
        public int ID;
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age;
        [DataMember]
        public int Salary;
    }
}
