using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Vehicle, VehicleViewModel>();
            Mapper.CreateMap<VehicleViewModel, Vehicle>();
            Mapper.CreateMap<Manufacture, ManufactureViewModel>();
            Mapper.CreateMap<ManufactureViewModel, Manufacture>();
            Mapper.CreateMap<OwenrViewModel, Owner>();
            Mapper.CreateMap<Owner, OwenrViewModel>();
            Mapper.CreateMap<VType, VTypeViewModel>();
            Mapper.CreateMap<VTypeViewModel, VType>();
            Mapper.CreateMap<Country, CountryViewModel>();
            Mapper.CreateMap<CountryViewModel, Country>();
            Mapper.CreateMap<FuelType, FuelTypeViewModel>();
            Mapper.CreateMap<FuelTypeViewModel, FuelType>();
            Mapper.CreateMap<Appointment, AppointmentViewModel>();
            Mapper.CreateMap<AppointmentViewModel, Appointment>();
            Mapper.CreateMap<Driver, DriverViewModel>();
            Mapper.CreateMap<DriverViewModel, Driver>();
        }
        
    }
}