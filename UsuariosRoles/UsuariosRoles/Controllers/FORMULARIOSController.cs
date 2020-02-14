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
        private string nombre = "Formularios".ToLower();
        private string metodo;
        private DatoSesion datoSesion;

        // GET: FORMULARIOS
        public ActionResult Index()
        {
            datoSesion = (DatoSesion)Session["datoSesion"];
            FUNCIONES funcion = datoSesion.getFuncion(nombre);
            /*
            if (datoSesion == null)
            {
                funcion = DatoSesion.FuncionSinDatos();
            }
            */
            ViewBag.funcion = funcion;
            return View(db.FORMULARIOS.ToList());
        }

        // GET: FORMULARIOS/Details/5
        public ActionResult Details(decimal id)
        {
            metodo = "LEER";
            DatoSesion datoSesion = (DatoSesion)Session["datoSesion"];
            if (!datoSesion.RevisarPermiso(nombre, metodo))
            {
                ViewBag.funcion = datoSesion.getFuncion(nombre);
                var users = db.USUARIOS.Include(u => u.ROLES);
                return View("Index", users.ToList());
            }
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
                fORMULARIOS.ID = db.FORMULARIOS.Max(x => x.ID) + 1;
                db.FORMULARIOS.Add(fORMULARIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fORMULARIOS);
        }

        // GET: FORMULARIOS/Edit/5
        public ActionResult Edit(decimal id)
        {
            metodo = "EDITAR";
            DatoSesion datoSesion = (DatoSesion)Session["datoSesion"];
            if (!datoSesion.RevisarPermiso(nombre, metodo))
            {
                ViewBag.funcion = datoSesion.getFuncion(nombre);
                var users = db.USUARIOS.Include(u => u.ROLES);
                return View("Index", users.ToList());
            }
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
            metodo = "BORRAR";
            DatoSesion datoSesion = (DatoSesion)Session["datoSesion"];
            if (!datoSesion.RevisarPermiso(nombre, metodo))
            {
                ViewBag.funcion = datoSesion.getFuncion(nombre);
                var users = db.USUARIOS.Include(u => u.ROLES);
                return View("Index", users.ToList());
            }
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
