using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarketPlace.Models;

namespace MarketPlace.Areas.AdmiMarketPlace.Controllers
{
    public class AdminServicesController : Controller
    {
        private Model1 db = new Model1();

        // GET: AdmiMarketPlace/AdminServices
        public ActionResult Index()
        {
            var tbl_services = db.tbl_services.Include(t => t.tbl_photo).Include(t => t.tbl_servicecategory);
            return View(tbl_services.ToList());
        }

        // GET: AdmiMarketPlace/AdminServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_services tbl_services = db.tbl_services.Find(id);
            if (tbl_services == null)
            {
                return HttpNotFound();
            }
            return View(tbl_services);
        }

        // GET: AdmiMarketPlace/AdminServices/Create
        public ActionResult Create()
        {
            ViewBag.PhotoId = new SelectList(db.tbl_photo, "PhotoId", "URL");
            ViewBag.ServiceCategoryId = new SelectList(db.tbl_servicecategory, "ServiceCategoryId", "Name");
            return View();
        }

        // POST: AdmiMarketPlace/AdminServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceId,Name,Price,Context,ServiceCategoryId,Date,Note,PhotoId,Baxis,Active")] tbl_services tbl_services)
        {
            if (ModelState.IsValid)
            {
                db.tbl_services.Add(tbl_services);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhotoId = new SelectList(db.tbl_photo, "PhotoId", "URL", tbl_services.PhotoId);
            ViewBag.ServiceCategoryId = new SelectList(db.tbl_servicecategory, "ServiceCategoryId", "Name", tbl_services.ServiceCategoryId);
            return View(tbl_services);
        }

        // GET: AdmiMarketPlace/AdminServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_services tbl_services = db.tbl_services.Find(id);
            if (tbl_services == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhotoId = new SelectList(db.tbl_photo, "PhotoId", "URL", tbl_services.PhotoId);
            ViewBag.ServiceCategoryId = new SelectList(db.tbl_servicecategory, "ServiceCategoryId", "Name", tbl_services.ServiceCategoryId);
            return View(tbl_services);
        }

        // POST: AdmiMarketPlace/AdminServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceId,Name,Price,Context,ServiceCategoryId,Date,Note,PhotoId,Baxis,Active")] tbl_services tbl_services)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_services).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhotoId = new SelectList(db.tbl_photo, "PhotoId", "URL", tbl_services.PhotoId);
            ViewBag.ServiceCategoryId = new SelectList(db.tbl_servicecategory, "ServiceCategoryId", "Name", tbl_services.ServiceCategoryId);
            return View(tbl_services);
        }

        // GET: AdmiMarketPlace/AdminServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_services tbl_services = db.tbl_services.Find(id);
            if (tbl_services == null)
            {
                return HttpNotFound();
            }
            return View(tbl_services);
        }

        // POST: AdmiMarketPlace/AdminServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_services tbl_services = db.tbl_services.Find(id);
            db.tbl_services.Remove(tbl_services);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
