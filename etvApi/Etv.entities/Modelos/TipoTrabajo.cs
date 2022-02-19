using System;
using System.Collections.Generic;

namespace Etv.entities.Modelos
{
    public partial class TipoTrabajo
    {
        public TipoTrabajo()
        {
            Ots = new HashSet<Ot>();
        }

        public int IdTipoTrabajo { get; set; }
        public string? Nombre { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Ot> Ots { get; set; }
    }
}
