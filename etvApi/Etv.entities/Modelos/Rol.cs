using System;
using System.Collections.Generic;

namespace Etv.entities.Modelos
{
    public partial class Rol
    {
        public Rol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
