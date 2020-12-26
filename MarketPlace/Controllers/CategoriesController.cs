using MarketPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers
{
    public class CategoriesController : Controller
    {
        Model1 db = new Model1();
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Kateqoriyalar()
        {
            var data = db.tbl_servicecategory.ToList();
            return View(data);
        }
        public ActionResult ServiceList(int id)
        {
            var data = db.tbl_services.Where(x => x.ServiceCategoryId == id).ToList();
            return View("ServiceList",data);
        }
    }
}