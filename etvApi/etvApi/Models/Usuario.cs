using System;
using System.Collections.Generic;

namespace etvApi.Models
{
    public partial class Usuario
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public int IdRol { get; set; }
        public int IdSucursal { get; set; }
        public bool Estado { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual Rol IdRolNavigation { get; set; } = null!;
        public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
    }
}
