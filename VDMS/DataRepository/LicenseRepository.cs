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
    public class LicenseRepository : ILicense
    {
        private ApplicationDbContext _dbcontext;
        private IVehicaleRepository _vehicale = new VehicalRepository();

        LicenseViewModel ILicense.CreatView()
        {
            var license = new LicenseViewModel();
            var vehicaleView = _vehicale.GetAllVehicle();
            license.Vehicles = vehicaleView;            
            return license;
        }

        bool ILicense.Delete(License license)
        {
            throw new NotImplementedException();
        }

        bool ILicense.Edit(License license)
        {
            throw new NotImplementedException();
        }

        LicenseViewModel ILicense.Get(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<LicenseViewModel> ILicense.GetAll()
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var res = _dbcontext.License.Include(V => V.vehicle).Where(L => L.Expiry > DateTime.Today).ToList().Select(Mapper.Map<License, LicenseViewModel>);
                return res;
            }
        }

        IEnumerable<LicenseViewModel> ILicense.NeartRenewal()
        {
            DateTime dateTime = DateTime.Now.AddMonths(3);
            using (_dbcontext = new ApplicationDbContext())
            {
                var res = _dbcontext.License.Include(V => V.vehicle).Where(L => L.Expiry <= dateTime).ToList().Select(Mapper.Map<License, LicenseViewModel>);
                return res;
            }
        }

        bool ILicense.Save(License license)
        {
            if (license != null)
            {
                using (_dbcontext = new ApplicationDbContext())
                {
                    _dbcontext.License.Add(license);
                    _dbcontext.SaveChanges();

                }
                return true;
            }
            return false;
        }


    }
}