using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.DataRepository
{
    public interface IManufacturesRepository
    {
        IEnumerable<ManufactureViewModel> GetAll();
        IEnumerable<CountryViewModel> GetAllCountry();

        bool Save(Manufacture viewModel);
        string Delete(int id);

        bool Edit(int id, Manufacture manufacture);

        ManufactureViewModel Detail(int id);
    }
}
