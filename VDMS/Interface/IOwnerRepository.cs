using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.DataRepository
{
    public interface IOwnerRepository
    {
        IEnumerable<OwenrViewModel> GetAll();

        bool Save(OwenrViewModel owner);
    }
}
