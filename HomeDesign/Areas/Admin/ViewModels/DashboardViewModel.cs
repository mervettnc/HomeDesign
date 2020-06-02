using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeDesign.Areas.Admin.ViewModels
{
    public class DashboardViewModel
    {
        public int CategoryCount { get; set; }
        public int ProjectCount { get; set; }
        public int UserCount { get; set; }
        public int AdminCount { get; set; }
   
    }
}