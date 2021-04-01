using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDMS.ViewModel;
using VDMS.Models;

namespace VDMS.DataRepository
{
    public interface IVehicaleRepository
    {
       Vehicle Save(Vehicle vehicle);
       bool Edit(int id, Vehicle vehicle);
       IEnumerable<VehicleViewModel> GetAllVehicle();
       Vehicle GetVehicle(int id);
       bool Delete(int id);
       VehicleViewModel View();
    }
}
