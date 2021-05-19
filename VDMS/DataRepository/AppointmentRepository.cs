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
    public class AppointmentRepository : IAppointment
    {
        private ApplicationDbContext _dbcontext;

        bool IAppointment.Delete(Appointment appointment)
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var appointmentinDb = _dbcontext.Appointments.Single(A => A.Id == appointment.Id);
                if (appointmentinDb != null)
                {
                    _dbcontext.Appointments.Remove(appointmentinDb);
                    _dbcontext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        bool IAppointment.Edit(Appointment appointment)
        {
            var returnVal = false;
            using (_dbcontext = new ApplicationDbContext())
            {
                var appoimentinDb = _dbcontext.Manufactures.Single(M => M.Id == appointment.Id);
                if (appoimentinDb != null)
                {
                    appoimentinDb.Name = appointment.AppointmentName;                   
                    _dbcontext.SaveChanges();
                    returnVal = true;
                }

            }

            return returnVal;
        }

        AppointmentViewModel IAppointment.Get(int Id)
        {
            var appointmentView = new AppointmentViewModel();
            using (_dbcontext = new ApplicationDbContext())
            {
                var appointment = _dbcontext.Appointments.Single(A => A.Id == Id);
                if (appointment != null)
                {
                    appointmentView = Mapper.Map<Appointment,AppointmentViewModel>(appointment);

                }
            }

            return appointmentView;
        }

        IEnumerable<AppointmentViewModel> IAppointment.GetAll()
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var appointments = _dbcontext.Appointments.ToList().Select(Mapper.Map<Appointment, AppointmentViewModel>);
                return appointments;
            }
        }

        AppointmentViewModel IAppointment.Save(Appointment appointment)
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                _dbcontext.Appointments.Add(appointment);
                _dbcontext.SaveChanges();

               var returnObj = Mapper.Map<Appointment,AppointmentViewModel>(appointment);
                return returnObj;
            }
        }
    }
}