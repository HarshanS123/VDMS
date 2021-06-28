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
    public class InsuranceController : Controller
    {
        private IInsuranceRepository _insurance = new InsuranceRepository();
        // GET: Insurance
        public ActionResult Index()
        {
            var insurans = _insurance.GetAll();
            return View(insurans);
        }

        // GET: Insurance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Insurance/Create
        public ActionResult Create()
        {
            var viewmodel = _insurance.CreatView();
            return View(viewmodel);
        }

        // POST: Insurance/Create
        [HttpPost]
        public ActionResult Create(InsuranceViewModel viewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                   var insmodel = Mapper.Map<InsuranceViewModel, Insurance>(viewModel);
                   var returnval =  _insurance.Save(insmodel);
                    if (returnval)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Create");

            }
            catch (Exception ex)
            {

                return View("Create");
            }
        }

        // GET: Insurance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Insurance/Edit/5
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

        // GET: Insurance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Insurance/Delete/5
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
