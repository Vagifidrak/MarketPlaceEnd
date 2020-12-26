using MarketPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers
{
    public class HeroController : Controller
    {
        Model1 db = new Model1();
        // GET: Hero
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HeroList()
        {
            return View(db.tbl_servicecategory.OrderByDescending(x => x.ServiceCategoryId).Take(3).ToList());
        }
    }
}