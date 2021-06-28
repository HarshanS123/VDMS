using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VDMS.DataRepository;
using VDMS.Interface;

namespace VDMS.Controllers
{
    public class HomeController : Controller
    {
        private IHomeRepository _homeRepository = new HomeRepository();
        public ActionResult Index()
        {
            var homedata = _homeRepository.GetHome();

            return View(homedata);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}