using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_WPF
{
    class CompanyPresenter : IPresenter
    {
        private IModel _model;
        private ICompanyView _companyView;

        public CompanyPresenter(ICompanyView view)
        {
            _companyView = view;
            _model = new CompanyModel();
            _model.LoadModel(null);
        }

        public void LoadData()
        {
            CompanyModel temp = _model as CompanyModel;
            _companyView.CompanyName = temp.Company.Name;
            _companyView.Departments = temp.Company.Departments;
        }

        private void OpenEditWindow(DepartmentModel dm)
        {
            EditDeportmant editDeportmantWindow = new EditDeportmant(dm);
            var result = editDeportmantWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                LoadData();
            }
        }

        public void Show()
        {
            DepartmentModel dm = new DepartmentModel("Новый департамент");
            dm.NewModel(_model);
            OpenEditWindow(dm);
        }
        public void Hide()
        {

        }
        public void Remove()
        {
            _model.Remove(_companyView.SelectedDepartment);
            LoadData();
        }

        public void SaveData()
        {
            CompanyModel temp = _model as CompanyModel;
            temp.Company.Name = _companyView.CompanyName;
            _model.SaveModel(null);
        }

        public void Edit()
        {
            DepartmentModel dm = new DepartmentModel(_companyView.SelectedDepartment);
            dm.LoadModel(_model);
            OpenEditWindow(dm);
        }
    }
}
