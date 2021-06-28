using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Interface;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.DataRepository
{
    public class InsuranceCompaniesRepository : IInsuranceCompanies
    {
        private ApplicationDbContext _dbcontext;        
        IEnumerable<IncuranceCompanyViewModel> IInsuranceCompanies.GetAll()
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var res = _dbcontext.IncuranceCompanies.ToList().Select(Mapper.Map<IncuranceCompany, IncuranceCompanyViewModel>);
                return res;
            }
        }
    }
}