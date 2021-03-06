﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UsuariosRoles.Models;
using Microsoft.AspNet.Identity;

namespace UsuariosRoles.Controllers
{
    public class USUARIOSController : Controller
    {
        private Entities db = new Entities();
        private string nombre = "Usuarios".ToLower();
        private string metodo;
        private DatoSesion datoSesion;

        // GET: USUARIOS
        public ActionResult Index()
        {
            datoSesion = (DatoSesion)Session["datoSesion"];
            //List<FUNCIONES> funciones = (List<FUNCIONES>)Session["funciones"];
            //FUNCIONES funcion = datoSesion.funciones.Where(x => x.FORMULARIOS.NOMBRE.ToLower() == nombre).First();
            // FUNCIONES funcion = datoSesion.getFuncion(nombre);
            //ViewBag.funcion = funcion;
            ViewBag.funcion = datoSesion.getFuncion(nombre);
            var uSUARIOS = db.USUARIOS.Include(u => u.ROLES);
            return View(uSUARIOS.ToList());
        }

        // GET: USUARIOS/Details/5
        public ActionResult Details(decimal id)
        {
            metodo = "LEER";
            datoSesion = (DatoSesion)Session["datoSesion"];
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
            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            if (uSUARIOS == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIOS);
        }

        // GET: USUARIOS/Create
        public ActionResult Create()
        {
            ViewBag.ROLES_ID = new SelectList(db.ROLES, "ID", "NOMBRE");
            return View();
        }

        // POST: USUARIOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,PASSWORD,ROLES_ID")] USUARIOS uSUARIOS)
        {
            if (ModelState.IsValid)
            {
                uSUARIOS.ID = db.USUARIOS.Max(x => x.ID) + 1;
                db.USUARIOS.Add(uSUARIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ROLES_ID = new SelectList(db.ROLES, "ID", "NOMBRE", uSUARIOS.ROLES_ID);
            return View(uSUARIOS);
        }

        // GET: USUARIOS/Edit/5
        public ActionResult Edit(decimal id)
        {
            metodo = "EDITAR";
            datoSesion = (DatoSesion)Session["datoSesion"];
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
            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            if (uSUARIOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ROLES_ID = new SelectList(db.ROLES, "ID", "NOMBRE", uSUARIOS.ROLES_ID);
            return View(uSUARIOS);
        }

        // POST: USUARIOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,PASSWORD,ROLES_ID")] USUARIOS uSUARIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ROLES_ID = new SelectList(db.ROLES, "ID", "NOMBRE", uSUARIOS.ROLES_ID);
            return View(uSUARIOS);
        }

        // GET: USUARIOS/Delete/5
        public ActionResult Delete(decimal id)
        {
            metodo = "BORRAR";
            datoSesion = (DatoSesion)Session["datoSesion"];
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
            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            if (uSUARIOS == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIOS);
        }

        // POST: USUARIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            db.USUARIOS.Remove(uSUARIOS);
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
