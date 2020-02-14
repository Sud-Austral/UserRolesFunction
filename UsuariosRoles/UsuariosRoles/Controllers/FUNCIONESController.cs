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
    public class FUNCIONESController : Controller
    {
        private Entities db = new Entities();
        private string nombre = "Funciones".ToLower();
        string metodo;

        // GET: FUNCIONES
        public ActionResult Index()
        {
            DatoSesion datoSesion = (DatoSesion)Session["datoSesion"];
            FUNCIONES funcion = datoSesion.getFuncion(nombre);
            ViewBag.funcion = funcion;
            var fUNCIONES = db.FUNCIONES.Include(f => f.BORRAR).Include(f => f.EDITAR).Include(f => f.FORMULARIOS).Include(f => f.LEER).Include(f => f.ROLES);
            return View(fUNCIONES.ToList());
        }

        // GET: FUNCIONES/Details/5
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
            FUNCIONES fUNCIONES = db.FUNCIONES.Find(id);
            if (fUNCIONES == null)
            {
                return HttpNotFound();
            }
            return View(fUNCIONES);
        }

        // GET: FUNCIONES/Create
        public ActionResult Create()
        {
            ViewBag.BORRAR_ID = new SelectList(db.BORRAR, "ID", "NOMBRE");
            ViewBag.EDITAR_ID = new SelectList(db.EDITAR, "ID", "NOMBRE");
            ViewBag.FORMULARIOS_ID = new SelectList(db.FORMULARIOS, "ID", "NOMBRE");
            ViewBag.LEER_ID = new SelectList(db.LEER, "ID", "NOMBRE");
            ViewBag.ROLES_ID = new SelectList(db.ROLES, "ID", "NOMBRE");
            return View();
        }

        // POST: FUNCIONES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,DETALLLE,ROLES_ID,LEER_ID,EDITAR_ID,BORRAR_ID,FORMULARIOS_ID")] FUNCIONES fUNCIONES)
        {
            if (ModelState.IsValid)
            {
                fUNCIONES.ID = db.FUNCIONES.Max(x => x.ID) + 1;
                db.FUNCIONES.Add(fUNCIONES);
                DatoSesion datoSesion = (DatoSesion)Session["datoSesion"];
                Session["datoSesion"] = new DatoSesion(datoSesion.user.NOMBRE, datoSesion.user.PASSWORD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BORRAR_ID = new SelectList(db.BORRAR, "ID", "NOMBRE", fUNCIONES.BORRAR_ID);
            ViewBag.EDITAR_ID = new SelectList(db.EDITAR, "ID", "NOMBRE", fUNCIONES.EDITAR_ID);
            ViewBag.FORMULARIOS_ID = new SelectList(db.FORMULARIOS, "ID", "NOMBRE", fUNCIONES.FORMULARIOS_ID);
            ViewBag.LEER_ID = new SelectList(db.LEER, "ID", "NOMBRE", fUNCIONES.LEER_ID);
            ViewBag.ROLES_ID = new SelectList(db.ROLES, "ID", "NOMBRE", fUNCIONES.ROLES_ID);
            return View(fUNCIONES);
        }

        // GET: FUNCIONES/Edit/5
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
            FUNCIONES fUNCIONES = db.FUNCIONES.Find(id);
            if (fUNCIONES == null)
            {
                return HttpNotFound();
            }
            ViewBag.BORRAR_ID = new SelectList(db.BORRAR, "ID", "NOMBRE", fUNCIONES.BORRAR_ID);
            ViewBag.EDITAR_ID = new SelectList(db.EDITAR, "ID", "NOMBRE", fUNCIONES.EDITAR_ID);
            ViewBag.FORMULARIOS_ID = new SelectList(db.FORMULARIOS, "ID", "NOMBRE", fUNCIONES.FORMULARIOS_ID);
            ViewBag.LEER_ID = new SelectList(db.LEER, "ID", "NOMBRE", fUNCIONES.LEER_ID);
            ViewBag.ROLES_ID = new SelectList(db.ROLES, "ID", "NOMBRE", fUNCIONES.ROLES_ID);
            return View(fUNCIONES);
        }

        // POST: FUNCIONES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,DETALLLE,ROLES_ID,LEER_ID,EDITAR_ID,BORRAR_ID,FORMULARIOS_ID")] FUNCIONES fUNCIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fUNCIONES).State = EntityState.Modified;
                db.SaveChanges();
                DatoSesion datoSesion = (DatoSesion)Session["datoSesion"];
                Session["datoSesion"] = new DatoSesion(datoSesion.user.NOMBRE, datoSesion.user.PASSWORD);
                return RedirectToAction("Index");
            }
            ViewBag.BORRAR_ID = new SelectList(db.BORRAR, "ID", "NOMBRE", fUNCIONES.BORRAR_ID);
            ViewBag.EDITAR_ID = new SelectList(db.EDITAR, "ID", "NOMBRE", fUNCIONES.EDITAR_ID);
            ViewBag.FORMULARIOS_ID = new SelectList(db.FORMULARIOS, "ID", "NOMBRE", fUNCIONES.FORMULARIOS_ID);
            ViewBag.LEER_ID = new SelectList(db.LEER, "ID", "NOMBRE", fUNCIONES.LEER_ID);
            ViewBag.ROLES_ID = new SelectList(db.ROLES, "ID", "NOMBRE", fUNCIONES.ROLES_ID);
            return View(fUNCIONES);
        }

        // GET: FUNCIONES/Delete/5
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
            FUNCIONES fUNCIONES = db.FUNCIONES.Find(id);
            if (fUNCIONES == null)
            {
                return HttpNotFound();
            }
            return View(fUNCIONES);
        }

        // POST: FUNCIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            FUNCIONES fUNCIONES = db.FUNCIONES.Find(id);
            db.FUNCIONES.Remove(fUNCIONES);
            db.SaveChanges();
            DatoSesion datoSesion = (DatoSesion)Session["datoSesion"];
            Session["datoSesion"] = new DatoSesion(datoSesion.user.NOMBRE, datoSesion.user.PASSWORD);
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
