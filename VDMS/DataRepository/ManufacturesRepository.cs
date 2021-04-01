using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Models;
using System.Net;
using System.Data.Entity;
using AutoMapper;
using VDMS.ViewModel;

namespace VDMS.DataRepository
{
    public class ManufacturesRepository : IManufacturesRepository
    {
        private ApplicationDbContext _dbcontext;

        public ManufacturesRepository()
        {
            
        }

        string IManufacturesRepository.Delete(int id)
        {
            using (_dbcontext = new ApplicationDbContext())
            {
               var manuf = _dbcontext.Manufactures.Single(M => M.Id == id);
                if (manuf!=null)
                {
                    _dbcontext.Manufactures.Remove(manuf);
                    _dbcontext.SaveChanges();
                    return "Success";
                }
                return "Not Found";
            }
        }

        ManufactureViewModel IManufacturesRepository.Detail(int id)
        {
            var returnObj = new ManufactureViewModel();
            using (_dbcontext = new ApplicationDbContext())
            {
                var manuf = _dbcontext.Manufactures.Single(M => M.Id == id);
                if (manuf != null)
                {
                    returnObj = Mapper.Map<Manufacture, ManufactureViewModel>(manuf);
                    
                }
            }

            return returnObj;
        }

        bool IManufacturesRepository.Edit(int id, Manufacture manufacture)
        {
            var returnVal = false;
            using (_dbcontext = new ApplicationDbContext())
            {
                var manuf =  _dbcontext.Manufactures.Single(M => M.Id==id);
                if (manuf != null)
                {
                    manuf.Name = manufacture.Name;
                    manuf.CountryId = manufacture.CountryId;                    
                    _dbcontext.SaveChanges();
                    returnVal = true;
                }
               
            }

            return returnVal;
        }

        IEnumerable<ManufactureViewModel> IManufacturesRepository.GetAll()
        {
            using (_dbcontext =  new ApplicationDbContext())
            {
                var manufactures = _dbcontext.Manufactures.Include(M => M.Country).ToList().Select(Mapper.Map<Manufacture, ManufactureViewModel>);
                return manufactures;
            }
                
        }

        IEnumerable<CountryViewModel> IManufacturesRepository.GetAllCountry()
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var countries = _dbcontext.Countries.ToList().Select(Mapper.Map<Country, CountryViewModel>);
                return countries;
            }
                
        }

        bool IManufacturesRepository.Save(Manufacture model)
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                _dbcontext.Manufactures.Add(model);
                _dbcontext.SaveChanges();

                return true;
            }
        }
    }
}