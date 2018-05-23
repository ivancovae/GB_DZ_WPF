namespace HW_WPF
{
    /// <summary>
    /// Презентер редактирования департамента
    /// </summary>
    class DepartmentPresenter : IPresenter
    {
        private IModel _model;
        private IDepartmentView _departmentView;
        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="view">объект представления</param>
        /// <param name="model">объект модели по сквозной связи</param>
        public DepartmentPresenter(IDepartmentView view, IModel model)
        {
            _departmentView = view;
            _model = model;
        }
        private void OpenEditWindow(EmployeeModel em)
        {
            EditEmpoyee editEmployeeWindow = new EditEmpoyee(em);
            var result = editEmployeeWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                LoadData();
            }
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
            DepartmentModel temp = _model as DepartmentModel;
            _departmentView.DepartmentName = temp.Department.Name;
            _departmentView.Employees = temp.Department.Employees;
        }
        /// <summary>
        /// Сохранение данных из представления в модель
        /// </summary>
        public void SaveData()
        {
            DepartmentModel temp = _model as DepartmentModel;
            temp.Department.Name = _departmentView.DepartmentName;
        }
        /// <summary>
        /// Создание нового окна редактирования, дочерняя цепочка MVP, для цепочки Департаментов
        /// </summary>
        public void Show()
        {
            EmployeeModel em = new EmployeeModel("Без имени");
            em.NewModel(_model);
            OpenEditWindow(em);
        }
        /// <summary>
        /// Удаление выбранной записи
        /// </summary>
        public void Remove()
        {
            if (_departmentView.SelectedEmployee == null)
                return;
            _model.Remove(_departmentView.SelectedEmployee);
            LoadData();
        }
        /// <summary>
        /// Изменение выбранной записи
        /// </summary>
        public void Edit()
        {
            if (_departmentView.SelectedEmployee == null)
                return;
            EmployeeModel em = new EmployeeModel(_departmentView.SelectedEmployee);
            em.LoadModel(_model);
            OpenEditWindow(em);
        }
    }
}
