namespace HW_WPF
{
    /// <summary>
    /// Презентер редактирования компании
    /// </summary>
    class CompanyPresenter : IPresenter
    {
        private IModel _model;
        private ICompanyView _companyView;
        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="view">объект представления</param>
        public CompanyPresenter(ICompanyView view)
        {
            _companyView = view;
            _model = new CompanyModel();
            _model.LoadModel(null);
        }
        /// <summary>
        /// Загрузка данных в представление
        /// </summary>
        public void LoadData()
        {
            CompanyModel temp = _model as CompanyModel;
            _companyView.CompanyName = temp.Company.Name;
            _companyView.Departments = temp.Company.Departments;
        }

        private void OpenEditWindow(DepartmentModel dm)
        {
            //EditDeportmant editDeportmantWindow = new EditDeportmant(dm);
            //var result = editDeportmantWindow.ShowDialog();
            //if (result.HasValue && result.Value)
            //{
            //    LoadData();
            //}
        }
        /// <summary>
        /// Создание нового окна редактирования, дочерняя цепочка MVP, для цепочки Департаментов
        /// </summary>
        public void Show()
        {
            DepartmentModel dm = new DepartmentModel("Новый департамент");
            dm.NewModel(_model);
            OpenEditWindow(dm);
        }
        /// <summary>
        /// Скрытие нового окна редактирования, дочерняя цепочка MVP, пока что не используется TO DO
        /// </summary>
        public void Hide()
        {

        }
        /// <summary>
        /// Удаление выбранной записи
        /// </summary>
        public void Remove()
        {
            if (_companyView.SelectedDepartment == null)
                return;
            _model.Remove(_companyView.SelectedDepartment);
            LoadData();
        }
        /// <summary>
        /// Сохранение данных из представления в модель
        /// </summary>
        public void SaveData()
        {
            CompanyModel temp = _model as CompanyModel;
            temp.Company.Name = _companyView.CompanyName;
            _model.SaveModel(null);
        }
        /// <summary>
        /// Изменение выбранной записи
        /// </summary>
        public void Edit()
        {
            if (_companyView.SelectedDepartment == null)
                return;
            DepartmentModel dm = new DepartmentModel(_companyView.SelectedDepartment);
            dm.LoadModel(_model);
            OpenEditWindow(dm);
        }
    }
}
