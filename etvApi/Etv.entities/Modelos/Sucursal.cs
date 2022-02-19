using System;
using System.Collections.Generic;

namespace Etv.entities.Modelos
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            Ots = new HashSet<Ot>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdSucursal { get; set; }
        public string Nombre { get; set; } = null!;
        public string Sigla { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<Ot> Ots { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
