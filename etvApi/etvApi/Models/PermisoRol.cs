using System;
using System.Collections.Generic;

namespace etvApi.Models
{
    public partial class PermisoRol
    {
        public int IdPermisoRol { get; set; }
        public int IdPermiso { get; set; }
        public int IdRol { get; set; }

        public virtual Permiso IdPermisoNavigation { get; set; } = null!;
        public virtual Rol IdRolNavigation { get; set; } = null!;
    }
}
