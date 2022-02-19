using System;
using System.Collections.Generic;

namespace Etv.entities.Modelos
{
    public partial class Marca
    {
        public Marca()
        {
            Modelos = new HashSet<Modelo>();
        }

        public int IdMarca { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}
