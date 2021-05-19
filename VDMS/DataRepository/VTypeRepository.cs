using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
                var vtype = _dbcontext.VTypes.ToList().Select(Mapper.Map<VType, VTypeViewModel>);                
                return vtype;
            }

        }

        bool IVTypes.Save(VTypeViewModel type)
        {
            if (type != null)
            {
                var obj = Mapper.Map<VTypeViewModel, VType>(type);
                using (_dbcontext = new ApplicationDbContext())
                {
                    _dbcontext.VTypes.Add(obj);
                    _dbcontext.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}