using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsuariosRoles.Models;

namespace UsuariosRoles.Controllers
{
    public class DatoSesion
    {
        private Entities db = new Entities();
        public USUARIOS user { get; set; }
        public List<FUNCIONES> funciones { get; set; }
        

        public DatoSesion()
        {

        }

        public DatoSesion(LoginViewModel model)
        {
            var usuarios = db.USUARIOS.Where(x => x.NOMBRE == model.Email && x.PASSWORD == model.Password).ToList();
            this.user = usuarios[0];
            var funcionesAux = db.FUNCIONES.Where(x => x.ROLES_ID == this.user.ROLES_ID);
            this.funciones = funcionesAux.ToList();
        }

        public DatoSesion(string email, string pass)
        {
            var usuarios = db.USUARIOS.Where(x => x.NOMBRE == email && x.PASSWORD == pass).ToList();
            this.user = usuarios[0];
            var funcionesAux = db.FUNCIONES.Where(x => x.ROLES_ID == this.user.ROLES_ID);
            this.funciones = funcionesAux.ToList();
        }

        public FUNCIONES getFuncion(string nombre)
        {
            FUNCIONES salida = new FUNCIONES();
            try
            {
                salida = this.funciones.Where(x => x.FORMULARIOS.NOMBRE.ToLower() == nombre).First();
            }
            catch (Exception)
            {
                salida = new FUNCIONES();
                salida.BORRAR_ID = 2;
                salida.EDITAR_ID = 2;
                salida.LEER_ID = 2;
            }            
            return salida;
        }

        public static FUNCIONES FuncionSinDatos()
        {
            FUNCIONES salida = new FUNCIONES();
            salida.BORRAR_ID = 2;
            salida.EDITAR_ID = 2;
            salida.LEER_ID = 2;
            return salida;
        }

        public bool RevisarPermiso(string nombre, string metodo)
        {
            bool salida = true;
            FUNCIONES funcion = getFuncion(nombre);
            switch (metodo)
            {
                case "LEER":
                    if(funcion.LEER.ID != 1)
                    {
                        salida = false;
                    }
                    break;
                case "EDITAR":
                    if (funcion.EDITAR.ID != 1)
                    {
                        salida = false;
                    }
                    break;
                case "BORRAR":
                    if (funcion.BORRAR.ID != 1)
                    {
                        salida = false;
                    }
                    break;

                default:
                    break;
            }
            return salida;
        }

        public void setFunciones()
        {
            this.funciones = db.FUNCIONES.Where(x => x.ROLES_ID == this.user.ROLES_ID).ToList();
        }



        
    }
}