using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.Interface
{
    interface IServiceRecords
    {
        bool Save(ServiceRecord serviceRecord);

        ServiceRecordViewModel Get(int Id);

        IEnumerable<ServiceRecordViewModel> GetAll();

        bool Edit(ServiceRecord serviceRecord);

        bool Delete(ServiceRecord serviceRecord);

        ServiceRecordViewModel CreatView();
    }
}
