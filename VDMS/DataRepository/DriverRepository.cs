using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VDMS.Interface;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.DataRepository
{
    public class DriverRepository : IDriverRepository
    {
        private ApplicationDbContext _dbcontext;
        private IAppointment _appoiment;

        DriverViewModel IDriverRepository.Create()
        {
            _appoiment = new AppointmentRepository();
            var appoiment = _appoiment.GetAll();
            DriverViewModel driverViewModel = new DriverViewModel() 
            { 
                Appointments = appoiment,
                
            };

            return driverViewModel;
        }

        string IDriverRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        DriverViewModel IDriverRepository.Detail(int id)
        {
            throw new NotImplementedException();
        }

        bool IDriverRepository.Edit(int id, Driver driver)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DriverViewModel> IDriverRepository.GetAll()
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var res = _dbcontext.Drivers.Include(D => D.Appointment).ToList().Select(Mapper.Map<Driver, DriverViewModel>);
                return res;
            }
        }

        IEnumerable<DriverViewModel> IDriverRepository.GetAvailable()
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var available = _dbcontext.Drivers.Where(D => D.Status==true).Include(D => D.Appointment).ToList().Select(Mapper.Map<Driver, DriverViewModel>);
                return available;
            }
        }

        bool IDriverRepository.Save(Driver viewModel)
        {
            var returnval = false;
            using (_dbcontext = new ApplicationDbContext())
            {
                _dbcontext.Drivers.Add(viewModel);
                _dbcontext.SaveChanges();
                 returnval = true;

            }

            return returnval;
        }
    }
}