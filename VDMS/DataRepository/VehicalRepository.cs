using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Models;
using System.Net;
using System.Data.Entity;
using VDMS.ViewModel;

namespace VDMS.DataRepository
{
    public class VehicalRepository : IVehicaleRepository
    {
        private ApplicationDbContext _dbcontext;
        private IManufacturesRepository _imanufactures;
        private IVTypes _ivtype;
        private IOwnerRepository _iowner;

        public VehicalRepository()
        {           
            _imanufactures = new ManufacturesRepository();
            _ivtype = new VTypeRepository();
            _iowner = new OwnerRepository();
        }

        bool IVehicaleRepository.Edit(int id, Vehicle vehicle)
        {
            bool returnval = false;
            //var vehicleInDb = _dbcontext.Vehicles.SingleOrDefault(v => v.Id == id);
            //if (vehicleInDb!=null)
            //{
            //    Mapper.Map(vehicle, vehicleInDb);
            //    _dbcontext.SaveChanges();
            //    return returnval = true;
            //}

            return returnval;
        }

        IEnumerable<VehicleViewModel> IVehicaleRepository.GetAllVehicle()
        {
            using (_dbcontext =  new ApplicationDbContext())
            {
                var vehicles = _dbcontext.Vehicles.Include(v => v.Manufacture).Include(v => v.Owner).Include(v => v.Type).ToList().Select(Mapper.Map<Vehicle, VehicleViewModel>);
                return vehicles;
            }
                
        }

        Vehicle IVehicaleRepository.GetVehicle(int id)
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                return _dbcontext.Vehicles.SingleOrDefault(v => v.Id == id);
            }
        }

        Vehicle IVehicaleRepository.Save(Vehicle vehicle)
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                if (vehicle != null)
                {
                    _dbcontext.Vehicles.Add(vehicle);
                    _dbcontext.SaveChanges();
                }

                return vehicle;

            }

            
        }

        bool IVehicaleRepository.Delete(int id)
        {
            bool returnval = false;
            using (_dbcontext = new ApplicationDbContext())
            {
                var vehicleInDb = _dbcontext.Vehicles.SingleOrDefault(v => v.Id == id);
                if (vehicleInDb != null)
                {
                    _dbcontext.Vehicles.Remove(vehicleInDb);
                    _dbcontext.SaveChanges();
                    return returnval = true;
                }

                return returnval;
            }
               
            
        }

        VehicleViewModel IVehicaleRepository.View() 
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var Vehicale = new VehicleViewModel();               
                var vtypeList = _ivtype.GetAll();
                var ownerList = _iowner.GetAll();
                var manufactureList = _imanufactures.GetAll();

                Vehicale.Owners = ownerList;
                Vehicale.Manufactures = manufactureList;
                Vehicale.VTypes = vtypeList;

                return Vehicale;
            }
                

        }

    }
}