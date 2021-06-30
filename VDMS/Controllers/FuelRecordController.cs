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
    public class FuelRecordController : Controller
    {
        private IFuelRecords _frepo = new FuelRecordRepository();
        // GET: FuelRecord
        public ActionResult Index()
        {
            var flR = _frepo.GetAll();
            return View(flR);
        }

        // GET: FuelRecord/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FuelRecord/Create
        public ActionResult Create()
        {
            var initailObj = _frepo.CreatView();
            return View(initailObj);
        }

        // POST: FuelRecord/Create
        [HttpPost]
        public ActionResult Create(FuelRecordViewModel fuelRecord)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _frepo.Save(Mapper.Map<FuelRecordViewModel, FuelRecord>(fuelRecord));
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FuelRecord/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FuelRecord/Edit/5
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

        // GET: FuelRecord/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FuelRecord/Delete/5
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
