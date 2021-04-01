using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.DataRepository
{
    public class VTypeRepository : IVTypes
    {
        private ApplicationDbContext _dbcontext;

        public VTypeRepository()
        {
            
        }
        IEnumerable<VTypeViewModel> IVTypes.GetAll()
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var vtype=  _dbcontext.VTypes.ToList().Select(Mapper.Map<VType, VTypeViewModel>);
                return vtype;
            }
                
        }
    }
}