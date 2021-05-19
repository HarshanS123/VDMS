using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VDMS.DataRepository;
using VDMS.Interface;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.Controllers
{
    public class AssigningController : Controller
    {
        private IVehicaleRepository _vehical;
        private IDriverRepository _driver;
        private IAssigning _assigning;

        // GET: Assigning
        public ActionResult Index()
        {
            _driver = new DriverRepository();
            var drivers = _driver.GetAll();

            _vehical = new VehicalRepository();
            var vehicals = _vehical.GetAllVehicle();

            _assigning = new RecordRepository();
            var records = _assigning.GetAll();

            records.Where(R => R.TerminateDate == null).ToList();

            return View(records);


        }

   

        // GET: Assigning/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Assigning/Create
        public ActionResult AssigningtoDriver()
        {
            _driver = new DriverRepository();
           var drivers = _driver.GetAll();

            _vehical = new VehicalRepository();
            var vehicals = _vehical.GetAllVehicle();

            _assigning = new RecordRepository();
            var records =_assigning.GetAll();


            var avilbleVehicals =  vehicals.GroupJoin(records.Where(R => R.TerminateDate == null),
                            vehical => vehical.Id,
                            record => record.Id,
                            (x, y) => new { vehical = x, records = y })
                            .SelectMany(xy => xy.records.DefaultIfEmpty(),
                            (x, y) => new { vehical = x.vehical, record = y })
                            .Select(s => new 
                            { 
                                VehicalObj = s.vehical
                            });

            DriverVehicleRecordViewModel dv = new DriverVehicleRecordViewModel();
            dv.driverViewModels = drivers;
            
            var ListV = new List<VehicleViewModel>();

            foreach (var avilbleVehical in avilbleVehicals)
            {
                var obj = new VehicleViewModel();
                obj = avilbleVehical.VehicalObj;
                ListV.Add(obj);
            }
            dv.vehicleViewModels = ListV;
            return View(dv);
        }

        // POST: Assigning/Create
        [HttpPost]
        public ActionResult AssigningtoDriver(DriverVehicleRecordViewModel DVRecored)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _assigning = new RecordRepository();
                   var reusalt = _assigning.Save(AutoMapper.Mapper.Map<DriverVehicleRecordViewModel, DriverVehicleRecord>(DVRecored));
                    if (reusalt)
                    {
                        return RedirectToAction("Index");
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Assigning/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Assigning/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Assigning/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Assigning/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
