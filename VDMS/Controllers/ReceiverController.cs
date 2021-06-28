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
    public class ReceiverController : Controller
    {
        private IReceiver _receiver = new ReceiverRepository();
        // GET: Receiver
        public ActionResult Index()
        {
            var resObj =  _receiver.GetAll();
            return View(resObj);
        }

        // GET: Receiver/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Receiver/Create
        public ActionResult Create()
        {
           var receiver = _receiver.Create();
            return View(receiver);
        }

        // POST: Receiver/Create
        [HttpPost]
        public ActionResult Create(ReceiverViewModel reciverVeiweModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _receiver.Save(AutoMapper.Mapper.Map<ReceiverViewModel, Receiver>(reciverVeiweModel));
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Receiver/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Receiver/Edit/5
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

        // GET: Receiver/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Receiver/Delete/5
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
