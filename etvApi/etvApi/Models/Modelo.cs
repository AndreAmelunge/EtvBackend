using System;
using System.Collections.Generic;

namespace etvApi.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Ubs = new HashSet<Ub>();
        }

        public int IdModelo { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Estado { get; set; }
        public int IdMarca { get; set; }

        public virtual Marca IdMarcaNavigation { get; set; } = null!;
        public virtual ICollection<Ub> Ubs { get; set; }
    }
}
