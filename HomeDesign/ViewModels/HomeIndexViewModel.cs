using HomeDesign.Models;
using X.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeDesign.ViewModels
{
    public class HomeIndexViewModel
    {
        public IPagedList<Project> Projects { get; set; }
        public Category SelectedCategory { get; set; }
        public int? SelectedCategoryId { get; set; }
    }
}