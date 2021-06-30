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
        private IFuel _fuel;

        public VehicalRepository()
        {           
            _imanufactures = new ManufacturesRepository();
            _ivtype = new VTypeRepository();
            _iowner = new OwnerRepository();
            _fuel = new FuelRepository();
        }

        bool IVehicaleRepository.Edit(VehicleViewModel vehicle)
        {
            bool returnval = false;
            using (_dbcontext =  new ApplicationDbContext())
            {
                var vehicleInDb = _dbcontext.Vehicles.SingleOrDefault(v => v.Id == vehicle.Id);
                if (vehicleInDb != null)
                {
                    Mapper.Map(vehicle, vehicleInDb);
                    _dbcontext.SaveChanges();
                    return returnval = true;
                }
            }

            return returnval;
        }

        IEnumerable<VehicleViewModel> IVehicaleRepository.GetAllVehicle()
        {
            using (_dbcontext =  new ApplicationDbContext())
            {
                var res =  _dbcontext.Vehicles.Include(v => v.Manufacture).Include(v => v.Owner).Include(v => v.Type).Include(v => v.FuelType).ToList().Select(Mapper.Map<Vehicle, VehicleViewModel>);
                return res;
            }
                
        }

        VehicleViewModel IVehicaleRepository.GetVehicle(int id)
        {
            var Vehicale = new VehicleViewModel();

            using (_dbcontext = new ApplicationDbContext())
            {
                var ve = _dbcontext.Vehicles.SingleOrDefault(v => v.Id == id);
                Vehicale= Mapper.Map<Vehicle, VehicleViewModel>(ve);                
            }
            var vtypeList = _ivtype.GetAll();
            var ownerList = _iowner.GetAll();
            var manufactureList = _imanufactures.GetAll();
            var fuel = _fuel.GetAll();

            Vehicale.Owners = ownerList;
            Vehicale.Manufactures = manufactureList;
            Vehicale.VTypes = vtypeList;
            Vehicale.FuelTypes = fuel;

            return Vehicale;
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
            var Vehicale = new VehicleViewModel();
            var vtypeList = _ivtype.GetAll();
            var ownerList = _iowner.GetAll();
            var manufactureList = _imanufactures.GetAll();
            var fuel = _fuel.GetAll();

            Vehicale.Owners = ownerList;
            Vehicale.Manufactures = manufactureList;
            Vehicale.VTypes = vtypeList;
            Vehicale.FuelTypes = fuel;

            return Vehicale;

        }

        int IVehicaleRepository.VehicaleCount()
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var vehicleInDb = _dbcontext.Vehicles.ToList();                

                return vehicleInDb.Count;
            }
        }

        IEnumerable<VehicleViewModel> IVehicaleRepository.GetAllPoolVehicle()
        {
            var output = new List<VehicleViewModel>();
            using (_dbcontext = new ApplicationDbContext())
            {
                var res = _dbcontext.Vehicles.Include(v => v.Manufacture).Include(v => v.Owner).Include(v => v.Type).Include(v => v.FuelType).ToList();
                var returnList = res.Join(_dbcontext.ReceiverRecords.Where(r => r.TerminateDate == null).ToList(), 
                    mainvehicalslist => mainvehicalslist.Id,
                    recordlist => recordlist.VehicleId,
                    (mainvehicalslist, recordlist) => new Vehicle()
                    {
                        Id = mainvehicalslist.Id,
                        VehicleNo = mainvehicalslist.VehicleNo,
                        Type = mainvehicalslist.Type,
                        FuelType = mainvehicalslist.FuelType,
                        CylinderCapacity = mainvehicalslist.CylinderCapacity,
                        ManufacturedYear = mainvehicalslist.ManufacturedYear,
                        Manufacture = mainvehicalslist.Manufacture,
                        Owner = mainvehicalslist.Owner,
                    });
                foreach (var mainlist in res)
                {
                    if(returnList.Where(m => m.Id == mainlist.Id).FirstOrDefault() == null)
                    {
                        output.Add(Mapper.Map<Vehicle, VehicleViewModel>(mainlist));
                    }
                }
                return output;
            }
        }
    }
}