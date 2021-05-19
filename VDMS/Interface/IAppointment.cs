using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.Interface
{
    interface IAppointment
    {
        AppointmentViewModel Save(Appointment appointment);

        AppointmentViewModel Get(int Id);

        IEnumerable<AppointmentViewModel> GetAll();

        bool Edit(Appointment appointment);

        bool Delete(Appointment appointment);
    }
}
