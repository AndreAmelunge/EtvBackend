using System;
using System.Collections.Generic;

namespace etvApi.Models
{
    public partial class Ot
    {
        public int IdOt { get; set; }
        public string Codigo { get; set; } = null!;
        public DateTime FechaSolicitud { get; set; }
        public decimal PrecioTotal { get; set; }
        public int IdSucursal { get; set; }
        public int IdTipoTrabajo { get; set; }
        public int IdPersona { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
        public virtual TipoTrabajo IdTipoTrabajoNavigation { get; set; } = null!;
        public virtual OtDetalle OtDetalle { get; set; } = null!;
    }
}
