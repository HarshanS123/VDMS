using AutoMapper;
using DocumentFormat.OpenXml.InkML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VDMS.DataRepository;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.Controllers
{
    public class VehiclesController : Controller
    {
       // private ApplicationDbContext db = new ApplicationDbContext();
        private IVehicaleRepository _vrepo = new VehicalRepository();        

        // GET: Vehicles
        public ActionResult Index()
        {            
            var vehicles = _vrepo.GetAllVehicle();           
            return View(vehicles);
        }

        //// GET: Vehicles/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vehicle vehicle = db.Vehicles.Find(id);
        //    if (vehicle == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicle);
        //}

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            var viewmodel = _vrepo.View();
            return View(viewmodel);
        }

        //post: vehicles/create
        //to protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?linkid=317598.
        [HttpPost]        
        public ActionResult Create(VehicleViewModel vehicle)
        {
            if (ModelState.IsValid)
            { 
                var v = _vrepo.Save(Mapper.Map<VehicleViewModel, Vehicle>(vehicle));
                if (v.Id!=0)
                {
                    return RedirectToAction("index");
                }
                
            }
            
            return RedirectToAction("Create");
        }

        //// GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            int Vid = (int)id;            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);                
            }
            else
            {
                return View(_vrepo.GetVehicle(Vid));
            }            
           
        }

        //// POST: Vehicles/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleViewModel vehicle)
        {
            if (ModelState.IsValid)
            {
                _vrepo.Edit(vehicle);
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Edit", new { id = vehicle.Id});
        }

        //// GET: Vehicles/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vehicle vehicle = db.Vehicles.Find(id);
        //    if (vehicle == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicle);
        //}

        //// POST: Vehicles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Vehicle vehicle = db.Vehicles.Find(id);
        //    db.Vehicles.Remove(vehicle);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
