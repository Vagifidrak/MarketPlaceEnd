using MarketPlace.Models;
using MarketPlace.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers
{
    public class ServiceController : Controller
    {
        Model1 db = new Model1();
        // GET: Service
        public ActionResult Index(string searchTerm)
        {
            //HomeVM
            return View();
        }
    
        public ActionResult ServiceDetail(int id)
        {
            HomeVM VM = new HomeVM();
            VM.serviceSingle = db.tbl_services.Where(x => x.ServiceId == id).SingleOrDefault();
            return View(VM);
        }
        
    }
}