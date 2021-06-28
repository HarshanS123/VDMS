using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDMS.ViewModel;

namespace VDMS.Interface
{
    interface IInsuranceCompanies
    {
        IEnumerable<IncuranceCompanyViewModel> GetAll();
    }
}
