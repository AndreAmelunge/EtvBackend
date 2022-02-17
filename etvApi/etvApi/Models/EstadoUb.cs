using System;
using System.Collections.Generic;

namespace etvApi.Models
{
    public partial class EstadoUb
    {
        public EstadoUb()
        {
            Ubs = new HashSet<Ub>();
        }

        public int IdEstadoUb { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Ub> Ubs { get; set; }
    }
}
