using System;
using System.Collections.Generic;

namespace Etv.entities.Modelos
{
    public partial class Persona
    {
        public Persona()
        {
            Ots = new HashSet<Ot>();
        }

        public int IdPersona { get; set; }
        public string Nombre { get; set; } = null!;
        public string? APaterno { get; set; }
        public string? AMaterno { get; set; }
        public bool Estado { get; set; }
        public int IdCargo { get; set; }

        public virtual Cargo IdCargoNavigation { get; set; } = null!;
        public virtual Usuario Usuario { get; set; } = null!;
        public virtual ICollection<Ot> Ots { get; set; }
    }
}
