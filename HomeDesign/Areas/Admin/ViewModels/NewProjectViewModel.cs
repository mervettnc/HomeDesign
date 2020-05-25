using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeDesign.Areas.Admin.ViewModels
{
    public class NewProjectViewModel
    {
   
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [AllowHtml] //içerikte html izin vermesi için 
        public string Content { get; set; }
        public string PhotoPath { get; set; }

     
    }

}