using System.Runtime.Serialization;

namespace HW_WPF.Model
{
    [DataContract]
    public class CompanyTable
    {
        [DataMember]
        public int ID;
        [DataMember]
        public string Name { get; set; }
    }
}
