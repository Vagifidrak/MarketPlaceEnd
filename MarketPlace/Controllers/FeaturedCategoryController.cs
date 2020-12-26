using MarketPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers
{
    public class FeaturedCategoryController : Controller
    {
        Model1 db = new Model1();
        // GET: FeaturedCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FeaturedCategories()
        {
            return View(db.tbl_servicecategory.OrderByDescending(x=>x.ServiceCategoryId).Take(6).ToList());
        }
    }
}