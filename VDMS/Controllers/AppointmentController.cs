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
    public class AppointmentController : Controller
    {
        private IAppointment appoimnentDb ;
        // GET: Appointment
        public ActionResult Index()
        {
            appoimnentDb = new AppointmentRepository();
            var appoiment =appoimnentDb.GetAll();
            return View(appoiment);
        }
                

        // GET: Appointment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Create(AppointmentViewModel appoimnentViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    appoimnentDb = new AppointmentRepository();
                    var app = Mapper.Map<AppointmentViewModel, Appointment>(appoimnentViewModel);
                    appoimnentDb.Save(app);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }

                
            }
            return View();
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Appointment/Edit/5
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
               

        // POST: Appointment/Delete/5
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
