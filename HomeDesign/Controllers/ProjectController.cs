using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeDesign.Controllers
{
    public class ProjectController : BaseController
    {
        // GET: p/23/bohem-decoration-1
        [Route("p/{id}/{slug?}")]
        public ActionResult Show(int id,string slug)
        {
            var post = db.Projects.Find(id);

            if (post == null)
            {
                return HttpNotFound();
            }

            if (post.Slug != slug)
            {
                return RedirectToAction("Show", new { id = id, slug = post.Slug });
            }

            //var vm = new ShowPostViewModel()
            //{
            //    Post = post,
            //    CommentViewModel = new CommentViewModel()
            //};

            return View(post);
        }
    }
}