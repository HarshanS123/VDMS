using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Interface;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.DataRepository
{
    public class RecordRepository : IAssigning
    {
        private ApplicationDbContext _dbcontext;

        DriverVehicleRecordViewModel IAssigning.CreatrView()
        {
            DriverVehicleRecordViewModel newObj = new DriverVehicleRecordViewModel();
            return newObj;
        }

        IEnumerable<DriverVehicleRecordViewModel> IAssigning.GetAll()
        {
            using (_dbcontext =  new ApplicationDbContext())
            {
                var record = _dbcontext.DriverVehicleRecords.ToList().Select(Mapper.Map<DriverVehicleRecord, DriverVehicleRecordViewModel>);
                return record;
            }
        }

        bool IAssigning.Save(DriverVehicleRecord Record)
        {
            bool result = false;
            using (_dbcontext = new ApplicationDbContext())
            {
                if (Record != null)
                {
                    _dbcontext.DriverVehicleRecords.Add(Record);
                    _dbcontext.SaveChanges();
                    result = true;
                }

            }

            return result;
        }
    }
}