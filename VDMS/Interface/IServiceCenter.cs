using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.Interface
{
    interface IServiceCenter
    {
        IEnumerable<ServiceCenterViewModel> GetAll();

        bool Save(ServiceCenter serviceCenter);
        string Delete(int id);

        bool Edit(int id, ServiceCenter serviceCenter);

        ServiceCenterViewModel Detail(int id);
    }
}
