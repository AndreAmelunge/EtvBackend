using System;
using System.Collections.Generic;

namespace etvApi.Models
{
    public partial class Ub
    {
        public Ub()
        {
            OtDetalles = new HashSet<OtDetalle>();
        }

        public int IdUb { get; set; }
        public string Codigo { get; set; } = null!;
        public string Placa { get; set; } = null!;
        public string? TarjetaOperativa { get; set; }
        public int IdTipoUb { get; set; }
        public string? Ano { get; set; }
        public int IdBlindador { get; set; }
        public int IdModelo { get; set; }
        public int EstadoUb { get; set; }

        public virtual EstadoUb EstadoUbNavigation { get; set; } = null!;
        public virtual Blindador IdBlindadorNavigation { get; set; } = null!;
        public virtual Modelo IdModeloNavigation { get; set; } = null!;
        public virtual TipoUb IdTipoUbNavigation { get; set; } = null!;
        public virtual ICollection<OtDetalle> OtDetalles { get; set; }
    }
}
