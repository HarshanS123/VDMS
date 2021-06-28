using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.Interface
{
    interface ILicense
    {
        bool Save(License license);

        LicenseViewModel Get(int Id);

        IEnumerable<LicenseViewModel> GetAll();

        bool Edit(License license);

        bool Delete(License license);

        LicenseViewModel CreatView();

        IEnumerable<LicenseViewModel> NeartRenewal();


    }
}
