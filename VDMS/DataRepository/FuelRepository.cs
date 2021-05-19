using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.DataRepository
{
    public class FuelRepository : IFuel
    {
        private ApplicationDbContext _dbcontext;
        IEnumerable<FuelTypeViewModel> IFuel.GetAll()
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var type = _dbcontext.FuelTypes.ToList().Select(Mapper.Map<FuelType,FuelTypeViewModel>);
                return type;
            }
        }
    }
}