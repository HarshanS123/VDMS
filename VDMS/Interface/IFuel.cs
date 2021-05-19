using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDMS.ViewModel;

namespace VDMS.DataRepository
{
    interface IFuel
    {
        IEnumerable<FuelTypeViewModel> GetAll();
    }
}
