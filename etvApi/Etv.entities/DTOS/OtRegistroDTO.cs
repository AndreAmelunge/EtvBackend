namespace Etv.entities.DTOS
{
    public class OtRegistroDTO
    {
        public OtDTO Ot { get; set; }
        public OtDetalleDTO otDetalle { get; set; }
    }

    public class OtDTO
    {
        public int IdOt { get; set; }
        public string Codigo { get; set; } = null!;
        public DateTime FechaSolicitud { get; set; }
        public decimal PrecioTotal { get; set; }
        public int IdSucursal { get; set; }
        public int IdTipoTrabajo { get; set; }
        public int IdPersona { get; set; }

    }
    public class OtDetalleDTO
    {
        public string TrabajoSolicitado { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int IdUb { get; set; }
    }
}
