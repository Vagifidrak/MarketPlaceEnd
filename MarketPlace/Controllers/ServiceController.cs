using MarketPlace.Models;
using MarketPlace.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpGet]
        public ActionResult AddService()
        {
            ViewBag.ServiceCategoryId = new SelectList(db.tbl_servicecategory, "ServiceCategoryId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult AddService(tbl_services servis,string Name,decimal Price,string Context,HttpPostedFileBase image)
        {
            ViewBag.ServiceCategoryId = new SelectList(db.tbl_servicecategory, "ServiceCategoryId", "Name");

            var picture = new tbl_photo();
            if (image != null)
            {
                string pictureName = Guid.NewGuid().ToString().Replace("-", "");
                string imageExtension = Path.GetExtension(Request.Files[0].FileName);
                string imageWay = "/Upload/images/" + pictureName + imageExtension;
                Request.Files[0].SaveAs(Server.MapPath(imageWay));
                picture.URL = imageWay;
                db.SaveChanges();
            }
            var imageCopy = db.tbl_photo.Add(picture);
            servis.PhotoId = imageCopy.PhotoId;
            servis.Active = false;
            servis.Date = DateTime.Now;
            servis.Baxis = 0;
            //int providerId =Convert.ToInt32(db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name).Id);
            //servis.Servi
            db.tbl_services.Add(servis);
            db.SaveChanges();

            db.Service_To_User.Add(new Service_To_User()
            {
                serviceId = servis.ServiceId,
                userId = User.Identity.GetUserId()
            });
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }


    }
}