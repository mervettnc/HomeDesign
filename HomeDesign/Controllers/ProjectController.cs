using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeDesign.Controllers
{
    public class ProjectController : BaseController
    {
        // GET: p/bohem-decoration-1
        [Route("p/{slug}")]
        public ActionResult Show(string slug)
        {
            var project = db.Projects.FirstOrDefault(x => x.Slug == slug);
            if (project==null)
            {
                return HttpNotFound();
            }
            return View(project);
        }
    }
}