using HomeDesign.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeDesign.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            var vm = new DashboardViewModel
            { 
            
                CategoryCount=db.Categories.Count(),
                ProjectCount=db.Projects.Count(),
                UserCount=db.Users.Count(),
                AdminCount=db.Roles.FirstOrDefault(x=>x.Name=="admin").Users.Count()
            };
            return View(vm);
        }
    }
}