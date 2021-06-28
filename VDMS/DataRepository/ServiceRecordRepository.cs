using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Models;
using System.Net;
using System.Data.Entity;
using VDMS.ViewModel;
using VDMS.Interface;

namespace VDMS.DataRepository
{
    public class ServiceRecordRepository : IServiceRecords
    {
        private ApplicationDbContext _dbcontext;
        private IServiceCenter _serviceCenter;
        private IVehicaleRepository _vehicale;
        ServiceRecordViewModel IServiceRecords.CreatView()
        {
            _serviceCenter = new ServiceCenterRepository();
            var centers = _serviceCenter.GetAll();
            var serviceRecord = new ServiceRecordViewModel();
            _vehicale = new VehicalRepository();
            serviceRecord.ServiceCenters = centers;
            serviceRecord.vehicles = _vehicale.GetAllVehicle();
            return serviceRecord;
    }

        bool IServiceRecords.Delete(ServiceRecord serviceRecord)
        {
            throw new NotImplementedException();
        }

        bool IServiceRecords.Edit(ServiceRecord serviceRecord)
        {
            throw new NotImplementedException();
        }

        ServiceRecordViewModel IServiceRecords.Get(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ServiceRecordViewModel> IServiceRecords.GetAll()
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var res = _dbcontext.ServiceRecords.Include(v => v.Vehicle).Include(s => s.ServiceCenter).ToList().Select(Mapper.Map<ServiceRecord, ServiceRecordViewModel>);
                return res;
            }
        }

        bool IServiceRecords.Save(ServiceRecord serviceRecord)
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                if (serviceRecord != null)
                {
                    _dbcontext.ServiceRecords.Add(serviceRecord);
                    _dbcontext.SaveChanges();
                }

                return true;

            }
        }
    }
}