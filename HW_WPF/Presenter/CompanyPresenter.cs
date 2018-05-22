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
        private IPresenter _presenterDepartment;

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

        public void Show()
        {
            DepartmentModel md = new DepartmentModel(_companyView.SelectedDepartment);
            md.LoadModel(_model);
            EditDeportmant editDeportmantWindow = new EditDeportmant(md);
            var result = editDeportmantWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                md.SaveModel(_model);
            }
        }
        public void Hide()
        {

        }
        public void Remove()
        {

        }

        public void SaveData()
        {
            _model.SaveModel(null);
        }

        public void Edit()
        {
            DepartmentModel md = new DepartmentModel(_companyView.SelectedDepartment);
            md.LoadModel(_model);
            EditDeportmant editDeportmantWindow = new EditDeportmant(md);
            var result = editDeportmantWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                md.SaveModel(_model);
            }
        }
    }
}
