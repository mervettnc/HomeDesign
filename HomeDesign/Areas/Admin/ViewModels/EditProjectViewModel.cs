using HomeDesign.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeDesign.Areas.Admin.ViewModels
{
    public class EditProjectViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [AllowHtml] //içerikte html izin vermesi için 
        public string Content { get; set; }

        public string CurrentFeaturedImage { get; set; }

        [Display(Name = "Last Modified")]
        public DateTime ModificationTime { get; set; }

        [Display(Name = "Created")]
        public DateTime CreationTime { get; set; }

        [PostedImage]
        public HttpPostedFileBase FeaturedImage { get; set; }

        [Required]
        [Display(Name ="Short Url")]
        [StringLength(100)]
        public string Slug { get; set; }

     
    }

}