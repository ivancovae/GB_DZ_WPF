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
        }

        public void LoadData()
        {
            _model.LoadModel(null);
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
                dm.SaveModel(_model);
            }
        }

        public void Show()
        {
            DepartmentModel dm = new DepartmentModel("Новый департамент");
            dm.NewModel();
            OpenEditWindow(dm);
        }
        public void Hide()
        {

        }
        public void Remove()
        {

        }

        public void SaveData()
        {
            CompanyModel temp = _model as CompanyModel;
            temp.Company.Name = _companyView.CompanyName;
        }

        public void Edit()
        {
            DepartmentModel dm = new DepartmentModel(_companyView.SelectedDepartment);
            dm.LoadModel(_model);
            OpenEditWindow(dm);
        }
    }
}
