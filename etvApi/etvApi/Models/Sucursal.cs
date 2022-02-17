using System;
using System.Collections.Generic;

namespace etvApi.Models
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            Ots = new HashSet<Ot>();
        }

        public int IdSucursal { get; set; }
        public string Nombre { get; set; } = null!;
        public string Sigla { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<Ot> Ots { get; set; }
    }
}
