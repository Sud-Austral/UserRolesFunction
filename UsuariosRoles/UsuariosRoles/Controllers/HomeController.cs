using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UsuariosRoles.Models;


namespace UsuariosRoles.Controllers
{
    public class HomeController : Controller
    {
        private Entities db = new Entities();
        public ActionResult Index()
        {
            DatoSesion datoSesion = (DatoSesion)Session["datoSesion"];
            if (datoSesion == null)
            {
                return RedirectToAction("Salir", "Account");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult NewIndex()
        {
            USUARIOS user = (USUARIOS)Session["user"];
            //var fUNCIONES = db.FUNCIONES.Include(f => f.BORRAR).Include(f => f.EDITAR).Include(f => f.FORMULARIOS).Include(f => f.LEER).Include(f => f.ROLES);
            //var funciones = db.FUNCIONES.Include(f => f.FORMULARIOS).Where(x => x.ROLES_ID == user.ROLES_ID);
            DatoSesion datoSesion = (DatoSesion)Session["datoSesion"];
            try
            {
                ViewBag.funciones = datoSesion.funciones;
                ViewBag.user = datoSesion.user.NOMBRE;
            }
            catch (Exception)
            {
                ViewBag.user = null;
                ViewBag.funciones = null;
            }
            return View();
        }

        public ActionResult PreLogin()
        {
            return View();
        }
    }
}