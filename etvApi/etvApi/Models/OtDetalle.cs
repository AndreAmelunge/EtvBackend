using System;
using System.Collections.Generic;

namespace etvApi.Models
{
    public partial class OtDetalle
    {
        public int IdOtDetalle { get; set; }
        public string TrabajoSolicitado { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int IdOt { get; set; }
        public int IdUb { get; set; }

        public virtual Ot IdOtNavigation { get; set; } = null!;
        public virtual Ub IdUbNavigation { get; set; } = null!;
    }
}
