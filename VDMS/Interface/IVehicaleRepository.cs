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
       bool Edit(VehicleViewModel vehicle);
       IEnumerable<VehicleViewModel> GetAllVehicle();
       IEnumerable<VehicleViewModel> GetAllPoolVehicle();
       VehicleViewModel GetVehicle(int id);
       bool Delete(int id);
       VehicleViewModel View();
       int VehicaleCount();
    }
}
