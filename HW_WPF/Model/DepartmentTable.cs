using System.Runtime.Serialization;

namespace HW_WPF.Model
{
    /// <summary>
    /// Класс десириализации Json объекта департамент
    /// </summary>
    [DataContract]
    public class DepartmentTable
    {
        /// <summary>
        /// поле уникального номера
        /// </summary>
        [DataMember]
        public int ID;
        /// <summary>
        /// Свойство имени
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
