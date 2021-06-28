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
    public class ServiceCenterRepository : IServiceCenter
    {
        private ApplicationDbContext _dbcontext;
        string IServiceCenter.Delete(int id)
        {
            throw new NotImplementedException();
        }

        ServiceCenterViewModel IServiceCenter.Detail(int id)
        {
            throw new NotImplementedException();
        }

        bool IServiceCenter.Edit(int id, ServiceCenter serviceCenter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ServiceCenterViewModel> IServiceCenter.GetAll()
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var center = _dbcontext.ServiceCenters.ToList().Select(Mapper.Map<ServiceCenter, ServiceCenterViewModel>);
                return center;
            }
            
        }

        bool IServiceCenter.Save(ServiceCenter serviceCenter)
        {
            throw new NotImplementedException();
        }
    }
}