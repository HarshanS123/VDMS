using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Interface;
using VDMS.Models;
using VDMS.ViewModel;
using System.Data.Entity;
using MoralesLarios.Linq;

namespace VDMS.DataRepository
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private ApplicationDbContext _dbcontext;
        private IVehicaleRepository _vehicale = new VehicalRepository();
        private IInsuranceCompanies _insuranceCom = new InsuranceCompaniesRepository();

        InsuranceViewModel IInsuranceRepository.CreatView()
        {
            var insurance = new InsuranceViewModel();
            var vehicaleView = _vehicale.GetAllVehicle();
            var insCompany = _insuranceCom.GetAll();
            insurance.Vehicles = vehicaleView;
            insurance.IncuranceCompanies = insCompany;
            return insurance;


        }

        bool IInsuranceRepository.Delete(Insurance insurance)
        {
            throw new NotImplementedException();
        }

        bool IInsuranceRepository.Edit(Insurance insurance)
        {
            throw new NotImplementedException();
        }

        InsuranceViewModel IInsuranceRepository.Get(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<InsuranceViewModel> IInsuranceRepository.GetAll()
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var insurance = new List<InsuranceViewModel>();
                var InsuranceLIst = _dbcontext.Insurances.Where(obj => obj.Status == true).Include(ins => ins.IncuranceCompany).ToList();
              var result =  _dbcontext.Vehicles.LeftJoin(_dbcontext.Insurances.Where(obj => obj.Status==true).ToList(), V => V.Id, I => I.VehicleId, (V, I) => new { Vobj = V, Iobj = I }).Select(I => new
                            {
                                VehicleNo = I.Vobj.VehicleNo,   
                                Vid = I.Vobj.Id,


                            });
                foreach (var vehicale in result)
                {
                    Insurance insuranceOBj = new Insurance();
                    if (InsuranceLIst.Count > 0)
                    {
                       insuranceOBj = InsuranceLIst.Find(ins => ins.VehicleId == vehicale.Vid);                       

                    }

                    insurance.Add(new InsuranceViewModel()
                    {  
                        

                     VehicleId = vehicale.Vid,
                     StartDate = insuranceOBj.StartDate,
                     EndDate = insuranceOBj.EndDate,
                     PolicyNo = insuranceOBj.PolicyNo,
                     IncuranceCompany = insuranceOBj.IncuranceCompany,

                        Vehicle =  new Vehicle()
                        {
                            VehicleNo = vehicale.VehicleNo,
                            Id = vehicale.Vid,                            
                        }

                    });
                }

             
                return insurance;
            }
        }

        IEnumerable<InsuranceViewModel> IInsuranceRepository.NearTorenewal()
        {
            DateTime dateTime = DateTime.Now.AddMonths(3);

            using (_dbcontext = new ApplicationDbContext())
            {
                var insurance = new List<InsuranceViewModel>();
                var InsuranceLIst = _dbcontext.Insurances.Where(IN => IN.Status == true).ToList();
                var resultnear = _dbcontext.Vehicles.LeftJoin(_dbcontext.Insurances.Where(INS => INS.EndDate < dateTime).ToList(), V => V.Id, I => I.VehicleId, (V, I) => new { Vobj = V, Iobj = I }).Select(I => new
                {
                    VehicleNo = I.Vobj.VehicleNo,
                    Vid = I.Vobj.Id,


                });

                foreach (var vehicale in resultnear)
                {
                    Insurance insuranceOBj = new Insurance();
                    if (InsuranceLIst.Count > 0)
                    {
                        insuranceOBj = InsuranceLIst.Find(ins => ins.VehicleId == vehicale.Vid);

                    }

                    insurance.Add(new InsuranceViewModel()
                    {


                        VehicleId = vehicale.Vid,
                        StartDate = insuranceOBj.StartDate,
                        EndDate = insuranceOBj.EndDate,

                        Vehicle = new Vehicle()
                        {
                            VehicleNo = vehicale.VehicleNo,
                            Id = vehicale.Vid,
                        }

                    });
                }


                return insurance;
            }
        }

        bool IInsuranceRepository.Save(Insurance insurance)
        {
            if (insurance != null)
            {                
                using (_dbcontext = new ApplicationDbContext())
                {
                    _dbcontext.Insurances.Add(insurance);
                    _dbcontext.SaveChanges();

                }
                return true;
            }
            return false;
        }
    }
}