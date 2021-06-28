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
    public class LicenseController : Controller
    {
        private ILicense _license = new LicenseRepository();
        // GET: License
        public ActionResult Index()
        {
           var licences =  _license.GetAll();
            return View(licences);
        }

        // GET: License/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: License/Create
        public ActionResult Create()
        {
            var viewmodel = _license.CreatView();
            return View(viewmodel);
        }

        // POST: License/Create
        [HttpPost]
        public ActionResult Create(LicenseViewModel license)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   _license.Save(Mapper.Map<LicenseViewModel, License>(license));
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: License/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: License/Edit/5
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

        // GET: License/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: License/Delete/5
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
