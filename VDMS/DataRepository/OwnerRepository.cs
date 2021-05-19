using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.DataRepository
{
    public class OwnerRepository : IOwnerRepository
    {
        private ApplicationDbContext _dbcontext;

        public OwnerRepository()
        {

        }
        IEnumerable<OwenrViewModel> IOwnerRepository.GetAll()
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var returnlist = _dbcontext.Owners.ToList().Select(Mapper.Map<Owner, OwenrViewModel>);
                return returnlist;
            }

        }

        bool IOwnerRepository.Save(OwenrViewModel owner)
        {
            if (owner !=null)
            {
                var obj = Mapper.Map<OwenrViewModel,Owner>(owner);
                using (_dbcontext = new ApplicationDbContext())
                {
                    _dbcontext.Owners.Add(obj);
                    _dbcontext.SaveChanges();
                    
                }
                return true;
            }
            return false;
        }
    }
}