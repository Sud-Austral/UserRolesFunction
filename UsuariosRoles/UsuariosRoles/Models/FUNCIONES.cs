//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UsuariosRoles.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FUNCIONES
    {
        public decimal ID { get; set; }
        public string NOMBRE { get; set; }
        public string DETALLLE { get; set; }
        public decimal ROLES_ID { get; set; }
        public decimal LEER_ID { get; set; }
        public decimal EDITAR_ID { get; set; }
        public decimal BORRAR_ID { get; set; }
        public decimal FORMULARIOS_ID { get; set; }
    
        public virtual BORRAR BORRAR { get; set; }
        public virtual EDITAR EDITAR { get; set; }
        public virtual FORMULARIOS FORMULARIOS { get; set; }
        public virtual LEER LEER { get; set; }
        public virtual ROLES ROLES { get; set; }
    }
}
