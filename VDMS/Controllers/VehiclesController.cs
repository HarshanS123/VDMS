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

        // post: vehicles/create
        // to protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?linkid=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult create([Bind(Include = "id,vehicleno,typeid,engineno,chassino,color,seatingcapacity,dataoffirstreg,cylindercapacity,manufacturedyear,manufactureid,ownerid")] Vehicledto vehicle)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.vehicles.add(vehicle);
        //        db.savechanges();
        //        return RedirectToAction("index");
        //    }

        //    ViewBag.manufactureid = new SelectList(db.manufactures, "id", "name", vehicle.ManufactureId);
        //    ViewBag.ownerid = new SelectList(db.owners, "id", "name", vehicle.OwnerId);
        //    ViewBag.typeid = new SelectList(db.vtypes, "id", "name", vehicle.TypeId);
        //    return View(vehicle);
        //}

        //// GET: Vehicles/Edit/5
        //public ActionResult Edit(int? id)
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
        //    ViewBag.ManufactureId = new SelectList(db.Manufactures, "Id", "Name", vehicle.ManufactureId);
        //    ViewBag.OwnerId = new SelectList(db.Owners, "Id", "Name", vehicle.OwnerId);
        //    ViewBag.TypeId = new SelectList(db.VTypes, "Id", "Name", vehicle.TypeId);
        //    return View(vehicle);
        //}

        //// POST: Vehicles/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,VehicleNo,TypeId,EngineNo,ChassiNo,Color,SeatingCapacity,DataOfFirstReg,CylinderCapacity,ManufacturedYear,ManufactureId,OwnerId")] Vehicle vehicle)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(vehicle).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ManufactureId = new SelectList(db.Manufactures, "Id", "Name", vehicle.ManufactureId);
        //    ViewBag.OwnerId = new SelectList(db.Owners, "Id", "Name", vehicle.OwnerId);
        //    ViewBag.TypeId = new SelectList(db.VTypes, "Id", "Name", vehicle.TypeId);
        //    return View(vehicle);
        //}

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
