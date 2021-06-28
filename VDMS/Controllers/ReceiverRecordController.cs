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
    public class ReceiverRecordController : Controller
    {
        private IReceiverRecord _receiverRecord = new ReceiverRecordRepository();
        // GET: ReceiverRecord
        public ActionResult Index()
        {
           var receiverObj =  _receiverRecord.GetAll();
            return View(receiverObj);
        }

        // GET: ReceiverRecord/Details/5
        public ActionResult Details(int id)
        {            
            return View();
        }

        // GET: ReceiverRecord/Create
        public ActionResult Create()
        {
            var reciverR = _receiverRecord.CreatrView();
            return View(reciverR);
        }

        // POST: ReceiverRecord/Create
        [HttpPost]
        public ActionResult Create(ReceiverRecordViewModel receiverRecordViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _receiverRecord.Save(Mapper.Map<ReceiverRecordViewModel, ReceiverRecord>(receiverRecordViewModel));
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReceiverRecord/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReceiverRecord/Edit/5
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

        // GET: ReceiverRecord/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReceiverRecord/Delete/5
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
