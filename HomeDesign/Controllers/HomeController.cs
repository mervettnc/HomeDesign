using HomeDesign.Models;
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

        public ActionResult Projects(int? cid)
        {
            IQueryable<Project> projects = db.Projects;
            Category category = null;

            if (cid != null)
            {
                category = db.Categories.Find(cid);
                if (category==null)
                {
                    return HttpNotFound();
                }

                projects = projects.Where(x => x.CategoryId == cid);
            }

            var vm = new HomeIndexViewModel
            {
                Projects = projects.OrderByDescending(x => x.CreationTime).ToList(),
                SelectedCategory = category
            };

            return View(vm);
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CategoriesPartial()
        {
            var cats = db.Categories.OrderBy(x => x.CategoryName).ToList();
            return PartialView("_CategoriesPartial",cats);
        }
    }
}