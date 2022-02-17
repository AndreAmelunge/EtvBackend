using System;
using System.Collections.Generic;

namespace etvApi.Models
{
    public partial class Permiso
    {
        public Permiso()
        {
            PermisoRols = new HashSet<PermisoRol>();
        }

        public int IdPermiso { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<PermisoRol> PermisoRols { get; set; }
    }
}
