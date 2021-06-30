using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VDMS.DataRepository;
using VDMS.ViewModel;

namespace VDMS.Controllers
{
    public class VehicleTypeController : Controller
    {
        private IVTypes _type = new VTypeRepository();
        // GET: VehicleType
        public ActionResult Index()
        {
            var types = _type.GetAll();
            return View(types);
        }

        // GET: VehicleType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleType/Create
        [HttpPost]
        public ActionResult Create(VTypeViewModel Vtype)
        {
            var returnVal = false;
            try
            {
                if (ModelState.IsValid)
                {                   
                    returnVal = _type.Save(Vtype);                    
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleType/Edit/5
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

        // GET: VehicleType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleType/Delete/5
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
