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
    public class EssentialOilCategoriesController : Controller
    {
        private HolisticHealthContext db = new HolisticHealthContext();

        // GET: EssentialOilCategories
        public ActionResult Index()
        {
            return View(db.EssentialOilCategories.ToList());
        }

        // GET: EssentialOilCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EssentialOilCategory essentialOilCategory = db.EssentialOilCategories.Find(id);
            if (essentialOilCategory == null)
            {
                return HttpNotFound();
            }
            return View(essentialOilCategory);
        }

        // GET: EssentialOilCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EssentialOilCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EssentialOilCategoryID,Description")] EssentialOilCategory essentialOilCategory)
        {
            if (ModelState.IsValid)
            {
                db.EssentialOilCategories.Add(essentialOilCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(essentialOilCategory);
        }

        // GET: EssentialOilCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EssentialOilCategory essentialOilCategory = db.EssentialOilCategories.Find(id);
            if (essentialOilCategory == null)
            {
                return HttpNotFound();
            }
            return View(essentialOilCategory);
        }

        // POST: EssentialOilCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EssentialOilCategoryID,Description")] EssentialOilCategory essentialOilCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(essentialOilCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(essentialOilCategory);
        }

        // GET: EssentialOilCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EssentialOilCategory essentialOilCategory = db.EssentialOilCategories.Find(id);
            if (essentialOilCategory == null)
            {
                return HttpNotFound();
            }
            return View(essentialOilCategory);
        }

        // POST: EssentialOilCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EssentialOilCategory essentialOilCategory = db.EssentialOilCategories.Find(id);
            db.EssentialOilCategories.Remove(essentialOilCategory);
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
