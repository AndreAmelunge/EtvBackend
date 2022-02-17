using System;
using System.Collections.Generic;

namespace etvApi.Models
{
    public partial class TipoTrabajo
    {
        public TipoTrabajo()
        {
            Ots = new HashSet<Ot>();
        }

        public int IdTipoTrabajo { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Ot> Ots { get; set; }
    }
}
