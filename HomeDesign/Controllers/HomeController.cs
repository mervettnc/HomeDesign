using HomeDesign.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeDesign.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var vm = new HomeIndexViewModel
            {
                Projects = db.Projects.OrderByDescending(x=>x.CreationTime).ToList()
            };

            return View(vm);
        }

        public ActionResult Projects()
        {
            var vm = new HomeIndexViewModel
            {
                Projects = db.Projects.OrderByDescending(x => x.CreationTime).ToList()
            };

            return View(vm);
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}