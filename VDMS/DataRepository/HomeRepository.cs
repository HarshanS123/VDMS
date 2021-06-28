using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Interface;
using VDMS.ViewModel;

namespace VDMS.DataRepository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly HomeViewModel _homeViewModel = new HomeViewModel();
        private readonly IVehicaleRepository _vehicaleRepository = new VehicalRepository();
        private readonly IInsuranceRepository _insuranceRepository = new InsuranceRepository();
        private readonly ILicense _license = new LicenseRepository();
        HomeViewModel IHomeRepository.GetHome()
        {
            _homeViewModel.TotalVehicale = _vehicaleRepository.VehicaleCount();
            _homeViewModel.InsuranceForReneiwel = _insuranceRepository.NearTorenewal().Count();
            _homeViewModel.LicenseForReneiwel = _license.NeartRenewal().Count();
            return _homeViewModel;
        }
    }
}