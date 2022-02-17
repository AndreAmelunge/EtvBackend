using System;
using System.Collections.Generic;

namespace etvApi.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdCargo { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
