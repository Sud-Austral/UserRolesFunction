using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UsuariosRoles.Models;

namespace UsuariosRoles.Controllers
{
    public class ROLESController : Controller
    {
        private Entities db = new Entities();

        // GET: ROLES
        public ActionResult Index()
        {
            return View(db.ROLES.ToList());
        }

        // GET: ROLES/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROLES rOLES = db.ROLES.Find(id);
            if (rOLES == null)
            {
                return HttpNotFound();
            }
            return View(rOLES);
        }

        // GET: ROLES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ROLES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,DETALLLE")] ROLES rOLES)
        {
            if (ModelState.IsValid)
            {
                db.ROLES.Add(rOLES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rOLES);
        }

        // GET: ROLES/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROLES rOLES = db.ROLES.Find(id);
            if (rOLES == null)
            {
                return HttpNotFound();
            }
            return View(rOLES);
        }

        // POST: ROLES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,DETALLLE")] ROLES rOLES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOLES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rOLES);
        }

        // GET: ROLES/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROLES rOLES = db.ROLES.Find(id);
            if (rOLES == null)
            {
                return HttpNotFound();
            }
            return View(rOLES);
        }

        // POST: ROLES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ROLES rOLES = db.ROLES.Find(id);
            db.ROLES.Remove(rOLES);
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
