using System.Runtime.Serialization;

namespace HW_WPF.Model
{
    /// <summary>
    /// Класс десириализации Json объекта компания
    /// </summary>
    [DataContract]
    public class CompanyTable
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
