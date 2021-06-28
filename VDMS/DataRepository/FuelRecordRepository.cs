using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Interface;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.DataRepository
{
    public class FuelRecordRepository : IFuelRecords
    {
        private ApplicationDbContext _dbcontext;
        private IVehicaleRepository _vehicale = new VehicalRepository();
        FuelRecordViewModel IFuelRecords.CreatView()
        {
           var  FuelRecord = new FuelRecordViewModel();
            var vehicaleView = _vehicale.GetAllVehicle();
            FuelRecord.Vehicles = vehicaleView;
            return FuelRecord;
        }

        bool IFuelRecords.Delete(FuelRecord fuelRecord)
        {
            throw new NotImplementedException();
        }

        bool IFuelRecords.Edit(FuelRecord fuelRecord)
        {
            throw new NotImplementedException();
        }

        FuelRecordViewModel IFuelRecords.Get(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<FuelRecordViewModel> IFuelRecords.GetAll()
        {
            throw new NotImplementedException();
        }

        bool IFuelRecords.Save(FuelRecord fuelRecord)
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                if (fuelRecord != null)
                {
                    _dbcontext.FuelRecords.Add(fuelRecord);
                    _dbcontext.SaveChanges();
                }

                return true;

            }
        }
    }
}