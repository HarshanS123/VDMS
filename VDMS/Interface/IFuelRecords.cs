using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.Interface
{
    interface IFuelRecords
    {
        bool Save(FuelRecord fuelRecord);

        FuelRecordViewModel Get(int Id);

        IEnumerable<FuelRecordViewModel> GetAll();

        bool Edit(FuelRecord fuelRecord);

        bool Delete(FuelRecord fuelRecord);

        FuelRecordViewModel CreatView();
    }
}
