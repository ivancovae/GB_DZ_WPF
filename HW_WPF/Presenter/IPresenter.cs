using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_WPF
{
    interface IPresenter
    {
        void Show();
        void Hide();
        void LoadData();
        void SaveData();
        void Remove();
        void Edit();
    }
}
