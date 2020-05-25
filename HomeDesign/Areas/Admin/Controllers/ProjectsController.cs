using HomeDesign.Areas.Admin.ViewModels;
using HomeDesign.Helpers;
using HomeDesign.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeDesign.Areas.Admin.Controllers
{
    public class ProjectsController : AdminBaseController
    {
     
        public ActionResult New()
        {
            ViewBag.CategoryId =new SelectList(db.Categories.OrderBy(x => x.CategoryName).ToList(), "Id", "CategoryName");
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult New(NewProjectViewModel vm )
        {
            if (ModelState.IsValid)
            {
                Project project = new Project { 
                
                    CategoryId=vm.CategoryId,
                    Title=vm.Title,
                    Content=vm.Content,
                    UserId=User.Identity.GetUserId(),
                    Slug=UrlService.URLFriendly(vm.Title),
                    CreationTime=DateTime.Now,
                    ModificationTime=DateTime.Now,
                    PhotoPath=""
                    
                };
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.CategoryName).ToList(), "Id", "CategoryName");

            return View();
        }
    }
}