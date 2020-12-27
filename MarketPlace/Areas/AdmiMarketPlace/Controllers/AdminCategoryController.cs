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
    public class AdminCategoryController : Controller
    {
        private Model1 db = new Model1();

        // GET: AdmiMarketPlace/AdminCategory
        public ActionResult Index()
        {
            var tbl_servicecategory = db.tbl_servicecategory.Include(t => t.tbl_photo);
            return View(tbl_servicecategory.ToList());
        }

        // GET: AdmiMarketPlace/AdminCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_servicecategory tbl_servicecategory = db.tbl_servicecategory.Find(id);
            if (tbl_servicecategory == null)
            {
                return HttpNotFound();
            }
            return View(tbl_servicecategory);
        }

        // GET: AdmiMarketPlace/AdminCategory/Create
        public ActionResult Create()
        {
            ViewBag.PhotoId = new SelectList(db.tbl_photo, "PhotoId", "URL");
            return View();
        }

        // POST: AdmiMarketPlace/AdminCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceCategoryId,Name,Description,PhotoId")] tbl_servicecategory tbl_servicecategory)
        {
            if (ModelState.IsValid)
            {
                db.tbl_servicecategory.Add(tbl_servicecategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhotoId = new SelectList(db.tbl_photo, "PhotoId", "URL", tbl_servicecategory.PhotoId);
            return View(tbl_servicecategory);
        }

        // GET: AdmiMarketPlace/AdminCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_servicecategory tbl_servicecategory = db.tbl_servicecategory.Find(id);
            if (tbl_servicecategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhotoId = new SelectList(db.tbl_photo, "PhotoId", "URL", tbl_servicecategory.PhotoId);
            return View(tbl_servicecategory);
        }

        // POST: AdmiMarketPlace/AdminCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceCategoryId,Name,Description,PhotoId")] tbl_servicecategory tbl_servicecategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_servicecategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhotoId = new SelectList(db.tbl_photo, "PhotoId", "URL", tbl_servicecategory.PhotoId);
            return View(tbl_servicecategory);
        }

        // GET: AdmiMarketPlace/AdminCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_servicecategory tbl_servicecategory = db.tbl_servicecategory.Find(id);
            if (tbl_servicecategory == null)
            {
                return HttpNotFound();
            }
            return View(tbl_servicecategory);
        }

        // POST: AdmiMarketPlace/AdminCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_servicecategory tbl_servicecategory = db.tbl_servicecategory.Find(id);
            db.tbl_servicecategory.Remove(tbl_servicecategory);
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
