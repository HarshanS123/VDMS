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
                var owner =_dbcontext.Owners.ToList().Select(Mapper.Map<Owner, OwenrViewModel>);
                return owner;
            }            
             
        }
    }
}