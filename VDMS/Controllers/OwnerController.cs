using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VDMS.DataRepository;
using VDMS.ViewModel;

namespace VDMS.Controllers
{
    public class OwnerController : Controller
    {
        private IOwnerRepository _ownerRep = new OwnerRepository();
        // GET: Owner
        public ActionResult Index()
        {
            var owners =_ownerRep.GetAll();
            return View(owners);
        }

        // GET: Owner/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Owner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owner/Create
        [HttpPost]
        public ActionResult Create(OwenrViewModel owner)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ownerRep.Save(owner);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Owner/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Owner/Edit/5
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

        // GET: Owner/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Owner/Delete/5
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
