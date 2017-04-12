using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HolisticHealth.Models;

namespace HolisticHealth.Controllers
{
    public class EssentialOilsController : Controller
    {
        private HolisticHealthContext db = new HolisticHealthContext();

        // GET: EssentialOils
        public ActionResult Index()
        {
            var essentialOils = db.EssentialOils.Include(e => e.Type);
            return View(essentialOils.ToList());
        }

        // GET: EssentialOils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EssentialOil essentialOil = db.EssentialOils.Find(id);
            if (essentialOil == null)
            {
                return HttpNotFound();
            }
            return View(essentialOil);
        }

        // GET: EssentialOils/Create
        public ActionResult Create()
        {
            ViewBag.EssentialOilCategoryID = new SelectList(db.EssentialOilCategories, "EssentialOilCategoryID", "Description");
            return View();
        }

        // POST: EssentialOils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EssentialOilID,Description,EssentialOilCategoryID")] EssentialOil essentialOil)
        {
            if (ModelState.IsValid)
            {
                db.EssentialOils.Add(essentialOil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EssentialOilCategoryID = new SelectList(db.EssentialOilCategories, "EssentialOilCategoryID", "Description", essentialOil.EssentialOilCategoryID);
            return View(essentialOil);
        }

        // GET: EssentialOils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EssentialOil essentialOil = db.EssentialOils.Find(id);
            if (essentialOil == null)
            {
                return HttpNotFound();
            }
            ViewBag.EssentialOilCategoryID = new SelectList(db.EssentialOilCategories, "EssentialOilCategoryID", "Description", essentialOil.EssentialOilCategoryID);
            return View(essentialOil);
        }

        // POST: EssentialOils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EssentialOilID,Description,EssentialOilCategoryID")] EssentialOil essentialOil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(essentialOil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EssentialOilCategoryID = new SelectList(db.EssentialOilCategories, "EssentialOilCategoryID", "Description", essentialOil.EssentialOilCategoryID);
            return View(essentialOil);
        }

        // GET: EssentialOils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EssentialOil essentialOil = db.EssentialOils.Find(id);
            if (essentialOil == null)
            {
                return HttpNotFound();
            }
            return View(essentialOil);
        }

        // POST: EssentialOils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EssentialOil essentialOil = db.EssentialOils.Find(id);
            db.EssentialOils.Remove(essentialOil);
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
