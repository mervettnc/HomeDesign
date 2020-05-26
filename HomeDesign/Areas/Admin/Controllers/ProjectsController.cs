using HomeDesign.Areas.Admin.ViewModels;
using HomeDesign.Helpers;
using HomeDesign.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HomeDesign.Areas.Admin.Controllers
{
    public class ProjectsController : AdminBaseController
    {
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        public ActionResult New()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.CategoryName).ToList(), "Id", "CategoryName");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult New(NewProjectViewModel vm)
        {
            if (ModelState.IsValid)
            {
                
                Project project = new Project
                {

                    CategoryId = vm.CategoryId,
                    Title = vm.Title,
                    Content = vm.Content,
                    UserId = User.Identity.GetUserId(),
                    Slug = UrlService.URLFriendly(vm.Slug),
                    CreationTime = DateTime.Now,
                    ModificationTime = DateTime.Now,
                    PhotoPath = this.SaveImage(vm.FeaturedImage)

                };
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.CategoryName).ToList(), "Id", "CategoryName");

            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            //if (category.Posts.Count > 0)
            //{
            //    TempData["ErrorMessage"] = "A category must not contain any posts in order to be deleted.";
            //    return RedirectToAction("Index");
            //}
            this.DeleteImage(project.PhotoPath);//foto silinince klasörden de sil
            db.Projects.Remove(project);
            db.SaveChanges();
            TempData["SuccessMessage"] = "The Project  deleted successfully.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string ConvertToSlug(string title)
        {
            return UrlService.URLFriendly(title);
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var project = db.Projects.Find(id);
            if (project==null)
            {
                return HttpNotFound();
            }

            var vm = new EditProjectViewModel
            {
                Id=project.Id,
                CategoryId=project.CategoryId,
                Content=project.Content,
                CreationTime=project.CreationTime.Value,
                CurrentFeaturedImage=project.PhotoPath,
                ModificationTime=project.ModificationTime.Value,
                Slug=project.Slug,
                Title=project.Title
            };

            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.CategoryName).ToList(), "Id", "CategoryName");
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(EditProjectViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.CategoryName).ToList(), "Id", "CategoryName");

            return View(vm);
        }

    }
}