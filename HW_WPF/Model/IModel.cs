using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_WPF
{
    public interface IModel
    {
        void SaveModel(IModel model);
        void LoadModel(IModel model);

        void Remove(string name);
    }
}
