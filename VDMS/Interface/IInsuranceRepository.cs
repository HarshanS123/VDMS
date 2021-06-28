using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.Interface
{
    public interface IInsuranceRepository
    {
        bool Save(Insurance insurance);

        InsuranceViewModel Get(int Id);

        IEnumerable<InsuranceViewModel> GetAll();

        bool Edit(Insurance insurance);

        bool Delete(Insurance insurance);

        InsuranceViewModel CreatView();

        IEnumerable<InsuranceViewModel> NearTorenewal();
    }
}
