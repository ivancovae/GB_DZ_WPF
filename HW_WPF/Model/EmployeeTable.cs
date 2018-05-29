using System.Runtime.Serialization;

namespace HW_WPF.Model
{
    /// <summary>
    /// Класс десириализации Json объекта сотрудника
    /// </summary>
    [DataContract]
    public class EmployeeTable
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
        /// <summary>
        /// поле возраста
        /// </summary>
        [DataMember]
        public int Age;
        /// <summary>
        /// поле зарплаты
        /// </summary>
        [DataMember]
        public int Salary;
    }
}
