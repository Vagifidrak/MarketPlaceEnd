using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarketPlace.Models;

namespace MarketPlace.ViewModel
{
    public class HomeVM
    {
        public List<tbl_servicecategory> servicecategories { get; set; }
        public tbl_servicecategory servicecategorySingle { get; set; }
        public tbl_services serviceSingle { get; set; }
        public List<tbl_services> services{ get; set; }
        public ApplicationUser singleUser { get; set; }


    }
}