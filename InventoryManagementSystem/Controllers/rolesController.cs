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
    public class rolesController : Controller
    {
        private Db_InventoryEntities db = new Db_InventoryEntities();

        // GET: roles
        public ActionResult Index()
        {
            return View(db.tbl_roles.ToList());
        }

        // GET: roles/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_roles tbl_roles = db.tbl_roles.Find(id);
            if (tbl_roles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_roles);
        }

        // GET: roles/Create
        public ActionResult Create()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem() { Text = "Active", Value = "1" });
            li.Add(new SelectListItem() { Text = "In-Active", Value = "0" });
            ViewBag.DD = new SelectList(li, "Value", "Text");
            return View();
        }

        // POST: roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "r_id,r_name,r_status")] tbl_roles tbl_roles)
        {
            if (ModelState.IsValid)
            {
                db.tbl_roles.Add(tbl_roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_roles);
        }

        // GET: roles/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem() { Text = "Active", Value = "1" });
            li.Add(new SelectListItem() { Text = "In-Active", Value = "0" });
            ViewBag.DD = new SelectList(li, "Value", "Text");
            tbl_roles tbl_roles = db.tbl_roles.Find(id);
            if (tbl_roles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_roles);
        }

        // POST: roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "r_id,r_name,r_status")] tbl_roles tbl_roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_roles);
        }

        // GET: roles/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_roles tbl_roles = db.tbl_roles.Find(id);
            if (tbl_roles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_roles);
        }

        // POST: roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            tbl_roles tbl_roles = db.tbl_roles.Find(id);
            db.tbl_roles.Remove(tbl_roles);
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
