using MarketPlace.Models;
using MarketPlace.ViewModel;
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

        public ActionResult ServiceList(int? id,string searchTerm,int? sortBy)
        {
            sortBy = sortBy.HasValue ? sortBy : 1;
            //if (id == null)
            //    services=
            ServiceVM VM = new ServiceVM();
            VM.services = filterService(searchTerm,id,sortBy);
            VM.categories = db.tbl_servicecategory.ToList();
            VM.sortBy = sortBy.Value;
            VM.searchTerm = searchTerm;
            //var data = db.tbl_services.Where(x => x.ServiceCategoryId == id).ToList();
            return View("ServiceList",VM);
        }
        public List<tbl_services> filterService(string searchTerm,int? id,int? sortBy)
        {
            var service = db.tbl_services.AsQueryable();
            if (id.HasValue)
            {
                service = db.tbl_services.Where(x => x.ServiceCategoryId == id);
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
                service = service.Where(x => x.Name.Contains(searchTerm));
            }
            if (sortBy.HasValue)
            {
                switch (sortBy)
                {
                    
                    case 2:
                        service = service.OrderBy(x => x.Price);
                        break;
                    case 3:
                        service = service.OrderByDescending(x => x.Price);
                        break;
                    default:
                        service = service.OrderByDescending(x => x.ServiceId);
                        break;
                }
            }
            return service.ToList();

        }
    }
}