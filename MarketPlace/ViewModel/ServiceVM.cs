using MarketPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketPlace.ViewModel
{
    public class ServiceVM
    {
        public List<tbl_services> services{ get; set; }
        public List<tbl_servicecategory> categories { get; set; }
        public int sortBy { get; set; }
        public string searchTerm { get; set; }
    }
}