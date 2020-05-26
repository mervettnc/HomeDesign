﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeDesign.Controllers
{
    public class ErrorController : Controller
    {
        //https://stackoverflow.com/questions/13905164/how-to-make-custom-error-pages-work-in-asp-net-mvc-4

        public ViewResult Index()
        {
            return View();
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;  //you may want to set this to 200
            return View();
        }

    }
}