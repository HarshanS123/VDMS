using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.Interface
{
    interface IDriverRepository
    {
        IEnumerable<DriverViewModel> GetAll();

        IEnumerable<DriverViewModel> GetAvailable();

        bool Save(Driver viewModel);
        string Delete(int id);

        bool Edit(int id, Driver driver);

        DriverViewModel Detail(int id);

        DriverViewModel Create();
    }
}
