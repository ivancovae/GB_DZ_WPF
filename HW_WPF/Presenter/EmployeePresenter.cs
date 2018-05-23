using System;

namespace HW_WPF
{
    /// <summary>
    /// Презентер редактирования сотрудника
    /// </summary>
    class EmployeePresenter : IPresenter
    {
        private IModel _model;
        private IEmployeeView _employeeView;
        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="view">объект представления</param>
        /// <param name="model">объект модели по сквозной связи</param>
        public EmployeePresenter(IEmployeeView view, IModel model)
        {
            _employeeView = view;
            _model = model;
        }
        /// <summary>
        /// Скрытие нового окна редактирования, дочерняя цепочка MVP, пока что не используется TO DO
        /// </summary>
        public void Hide()
        {
            
        }
        /// <summary>
        /// Загрузка данных в представление
        /// </summary>
        public void LoadData()
        {
            EmployeeModel temp = _model as EmployeeModel;
            _employeeView.EmployeeName = temp.Employee.Name;
            _employeeView.EmployeeAge = temp.Employee.Age.ToString();
            _employeeView.EmployeeSalary = temp.Employee.Salary.ToString();
            if(temp.Employee.Department != null)
                _employeeView.EmployeeDepartment = temp.Employee.Department.Name;
            _employeeView.Deportments = temp.GetDepartments();
        }
        /// <summary>
        /// Сохранение данных из представления в модель
        /// </summary>
        public void SaveData()
        {
            EmployeeModel temp = _model as EmployeeModel;
            temp.Employee.Name = _employeeView.EmployeeName;
            temp.Employee.Age = Convert.ToInt32(_employeeView.EmployeeAge);
            temp.Employee.Salary = Convert.ToInt32(_employeeView.EmployeeSalary);
            temp.Remove(_employeeView.EmployeeName);
            var department = temp.GetDepartment(_employeeView.EmployeeDepartment);
            temp.Employee.ChangeDepartment(department);
            department.AddNewEmployee(temp.Employee);
        }
        /// <summary>
        /// Создание нового окна редактирования, дочерняя цепочка MVP, для цепочки Департаментов
        /// </summary>
        public void Show()
        {
            
        }
        /// <summary>
        /// Удаление выбранной записи
        /// </summary>
        public void Remove()
        {
            
        }
        /// <summary>
        /// Изменение выбранной записи
        /// </summary>
        public void Edit()
        {
            
        }
    }
}
