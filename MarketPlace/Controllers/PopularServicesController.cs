using MarketPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers
{
    public class PopularServicesController : Controller
    {
        Model1 db = new Model1();
        // GET: PopularServices
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PopularServisler()
        {
            return View(db.tbl_services.OrderByDescending(x=>x.ServiceId).Take(3).ToList());
        }
    }
}