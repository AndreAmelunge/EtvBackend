using System;
using System.Collections.Generic;

namespace etvApi.Models
{
    public partial class Rol
    {
        public Rol()
        {
            PermisoRols = new HashSet<PermisoRol>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<PermisoRol> PermisoRols { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
