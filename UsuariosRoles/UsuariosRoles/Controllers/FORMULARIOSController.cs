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
    public class FORMULARIOSController : Controller
    {
        private Entities db = new Entities();

        // GET: FORMULARIOS
        public ActionResult Index()
        {
            return View(db.FORMULARIOS.ToList());
        }

        // GET: FORMULARIOS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FORMULARIOS fORMULARIOS = db.FORMULARIOS.Find(id);
            if (fORMULARIOS == null)
            {
                return HttpNotFound();
            }
            return View(fORMULARIOS);
        }

        // GET: FORMULARIOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FORMULARIOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE")] FORMULARIOS fORMULARIOS)
        {
            if (ModelState.IsValid)
            {
                db.FORMULARIOS.Add(fORMULARIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fORMULARIOS);
        }

        // GET: FORMULARIOS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FORMULARIOS fORMULARIOS = db.FORMULARIOS.Find(id);
            if (fORMULARIOS == null)
            {
                return HttpNotFound();
            }
            return View(fORMULARIOS);
        }

        // POST: FORMULARIOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE")] FORMULARIOS fORMULARIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fORMULARIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fORMULARIOS);
        }

        // GET: FORMULARIOS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FORMULARIOS fORMULARIOS = db.FORMULARIOS.Find(id);
            if (fORMULARIOS == null)
            {
                return HttpNotFound();
            }
            return View(fORMULARIOS);
        }

        // POST: FORMULARIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            FORMULARIOS fORMULARIOS = db.FORMULARIOS.Find(id);
            db.FORMULARIOS.Remove(fORMULARIOS);
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
