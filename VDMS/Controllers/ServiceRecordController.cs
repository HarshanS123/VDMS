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
    public class ServiceRecordController : Controller
    {
        private IServiceRecords _serviceRecord = new ServiceRecordRepository();
        // GET: ServiceRecord
        public ActionResult Index()
        {
            var serviceR = _serviceRecord.GetAll();
            return View(serviceR);
        }

        // GET: ServiceRecord/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceRecord/Create
        public ActionResult Create()
        {
            var service = _serviceRecord.CreatView();
            return View(service);
        }

        // POST: ServiceRecord/Create
        [HttpPost]
        public ActionResult Create(ServiceRecordViewModel serviceRecordView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceRecord.Save(AutoMapper.Mapper.Map<ServiceRecordViewModel, ServiceRecord>(serviceRecordView));
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceRecord/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServiceRecord/Edit/5
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

        // GET: ServiceRecord/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceRecord/Delete/5
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
