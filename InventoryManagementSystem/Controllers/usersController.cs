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
    public class usersController : Controller
    {
        private Db_InventoryEntities db = new Db_InventoryEntities();

        // GET: users
        public ActionResult Index()
        {
            var tbl_users = db.tbl_users.Include(t => t.tbl_roles);
            return View(tbl_users.ToList());
        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_users tbl_users = db.tbl_users.Find(id);
            if (tbl_users == null)
            {
                return HttpNotFound();
            }
            return View(tbl_users);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            ViewBag.u_roleid = new SelectList(db.tbl_roles, "r_id", "r_name");
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "u_id,u_name,u_username,u_password,u_phone,u_email,u_status,u_roleid")] tbl_users tbl_users)
        {
            if (ModelState.IsValid)
            {
                db.tbl_users.Add(tbl_users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.u_roleid = new SelectList(db.tbl_roles, "r_id", "r_name", tbl_users.u_roleid);
            return View(tbl_users);
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_users tbl_users = db.tbl_users.Find(id);
            if (tbl_users == null)
            {
                return HttpNotFound();
            }
            ViewBag.u_roleid = new SelectList(db.tbl_roles, "r_id", "r_name", tbl_users.u_roleid);
            return View(tbl_users);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "u_id,u_name,u_username,u_password,u_phone,u_email,u_status,u_roleid")] tbl_users tbl_users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.u_roleid = new SelectList(db.tbl_roles, "r_id", "r_name", tbl_users.u_roleid);
            return View(tbl_users);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_users tbl_users = db.tbl_users.Find(id);
            if (tbl_users == null)
            {
                return HttpNotFound();
            }
            return View(tbl_users);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_users tbl_users = db.tbl_users.Find(id);
            db.tbl_users.Remove(tbl_users);
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
