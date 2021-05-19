using AutoMapper;
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
    public class DriverController : Controller
    {
        private IDriverRepository _driverrepo;
        
        // GET: Driver
        public ActionResult Index()
        {
            _driverrepo = new DriverRepository();
            var drivers = _driverrepo.GetAll();
            return View(drivers);
        }

        // GET: Driver/Details/5
        public ActionResult Details(int id)
        {            
            return View();
        }

        // GET: Driver/Create
        public ActionResult Create()
        {
            _driverrepo = new DriverRepository();
            var drivermodel= _driverrepo.Create();
            return View(drivermodel);
        }

        // POST: Driver/Create
        [HttpPost]
        public ActionResult Create(DriverViewModel driverViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var driver = Mapper.Map<DriverViewModel, Driver>(driverViewModel);
                    _driverrepo = new DriverRepository();
                    var returnval = _driverrepo.Save(driver);
                    if (returnval)
                    {
                        return RedirectToAction("Index");
                    }
                    
                }
                catch
                {
                    return RedirectToAction("Create");
                }
            }

            return RedirectToAction("Create");

        }

        // GET: Driver/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Driver/Edit/5
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

        // GET: Driver/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Driver/Delete/5
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
