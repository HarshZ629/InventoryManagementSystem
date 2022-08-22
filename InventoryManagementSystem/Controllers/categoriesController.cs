using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryManagementSystem;

namespace InventoryManagementSystem.Controllers
{
    public class categoriesController : Controller
    {
        private Db_InventoryEntities db = new Db_InventoryEntities();

        // GET: categories
        public ActionResult Index()
        {
            return View(db.tbl_categories.ToList());
        }

        // GET: categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_categories tbl_categories = db.tbl_categories.Find(id);
            if (tbl_categories == null)
            {
                return HttpNotFound();
            }
            return View(tbl_categories);
        }

        // GET: categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cat_id,cat_name,cat_status")] tbl_categories tbl_categories)
        {
            if (ModelState.IsValid)
            {
                db.tbl_categories.Add(tbl_categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_categories);
        }

        // GET: categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_categories tbl_categories = db.tbl_categories.Find(id);
            if (tbl_categories == null)
            {
                return HttpNotFound();
            }
            return View(tbl_categories);
        }

        // POST: categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cat_id,cat_name,cat_status")] tbl_categories tbl_categories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_categories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_categories);
        }

        // GET: categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_categories tbl_categories = db.tbl_categories.Find(id);
            if (tbl_categories == null)
            {
                return HttpNotFound();
            }
            return View(tbl_categories);
        }

        // POST: categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_categories tbl_categories = db.tbl_categories.Find(id);
            db.tbl_categories.Remove(tbl_categories);
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
