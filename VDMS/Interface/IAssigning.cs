using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.Interface
{
    interface IAssigning
    {
        IEnumerable<DriverVehicleRecordViewModel> GetAll();

        bool Save(DriverVehicleRecord record);
    }
}
