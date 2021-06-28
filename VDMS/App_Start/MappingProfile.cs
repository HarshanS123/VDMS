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
            Mapper.CreateMap<License,LicenseViewModel>();
            Mapper.CreateMap<LicenseViewModel, License>();
            Mapper.CreateMap<ServiceCenter, ServiceCenterViewModel>();
            Mapper.CreateMap<ServiceCenterViewModel, ServiceCenter>();
            Mapper.CreateMap<ServiceRecordViewModel, ServiceRecord>();
            Mapper.CreateMap<ServiceRecord, ServiceRecordViewModel>();
            Mapper.CreateMap<FuelRecord, FuelRecordViewModel>();
            Mapper.CreateMap<FuelRecordViewModel, FuelRecord>();
            Mapper.CreateMap<Receiver, ReceiverViewModel>();
            Mapper.CreateMap<ReceiverViewModel, Receiver>();
            Mapper.CreateMap<ReceiverRecordViewModel, ReceiverRecord>();
            Mapper.CreateMap<ReceiverRecord, ReceiverRecordViewModel>();
            Mapper.CreateMap<Insurance, InsuranceViewModel>();
            Mapper.CreateMap<InsuranceViewModel, Insurance>();
            Mapper.CreateMap<IncuranceCompany, IncuranceCompanyViewModel>();
            Mapper.CreateMap<IncuranceCompanyViewModel,IncuranceCompany>();
        }
        
    }
}