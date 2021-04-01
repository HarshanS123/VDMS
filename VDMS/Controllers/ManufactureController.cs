using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VDMS.DataRepository;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.Controllers
{
    public class ManufactureController : Controller
    {
        private IManufacturesRepository _mrepo = new ManufacturesRepository();
        // GET: Manufacture
        public ActionResult Index()
        {
           var manufactures =  _mrepo.GetAll();
            return View(manufactures);
        }

        // GET: Manufacture/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manufacture/Create
        public ActionResult Create()
        {
            var countries= _mrepo.GetAllCountry();

            return View(new ManufactureViewModel() 
            { 
             Countries = countries,
            });
        }

        // POST: Manufacture/Create
        [HttpPost]
        public ActionResult Create(ManufactureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var manufacture = Mapper.Map<ManufactureViewModel, Manufacture>(viewModel);
                _mrepo.Save(manufacture);                
            }

            return RedirectToAction("Index");
        }

        // GET: Manufacture/Edit/5
        public ActionResult Edit(int id)
        {
            var countries = _mrepo.GetAllCountry();
            var manufactuer = _mrepo.Detail(id);

            return View(new ManufactureViewModel()
            {
                Countries = countries,
                Name= manufactuer.Name,
                CountryId = manufactuer.CountryId,
            });
        }

        // POST: Manufacture/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ManufactureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var manufacture = Mapper.Map<ManufactureViewModel, Manufacture>(viewModel);
                _mrepo.Edit(id,manufacture);
            }
            return RedirectToAction("Index");           
        }
               

        // POST: Manufacture/Delete/5
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string result = _mrepo.Delete(id);
            if (result.Equals("Success"))
            {
                return Json(200);
            }
            else
            {
                return Json(404);
            }

        }
    }
}
