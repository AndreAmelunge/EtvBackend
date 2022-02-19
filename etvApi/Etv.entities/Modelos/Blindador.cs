using System;
using System.Collections.Generic;

namespace Etv.entities.Modelos
{
    public partial class Blindador
    {
        public Blindador()
        {
            Ubs = new HashSet<Ub>();
        }

        public int IdBlindador { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<Ub> Ubs { get; set; }
    }
}
