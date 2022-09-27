using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etv.entities.DTOS
{
    public class ReportDTO
    {
        public SucursalReport Sucursal { get; set; }
        public string Choferdesignado { get; set; }
        public string TipoTrabajo { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Detalle Detalle { get; set; }
    }

    public class SucursalReport
    {        
        public string Nombre { get; set; } = null!;
        public string Sigla { get; set; } = null!;
    }

    public class Vehiculo
    {
        public string Marca { get; set; } = null!;
        public string NumeroPlaca { get; set; } = null!;
        public string UB_VEHICULO_CUENTA { get; set; }
    }

    public class Detalle
    {
        public string Codigo { get; set; }
        public string Trabajosolicitado { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
    }
}
