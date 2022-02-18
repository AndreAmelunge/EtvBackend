using etvApi.Models;

namespace etvApi.DTOS
{
    public class OtResponceDTO : OtRegistroDTO
    {
        public UbResponceDto Ub { get; set; }
    }

    public class UbResponceDto
    {
        public int IdUb { get; set; }
        public string Codigo { get; set; } = null!;
        public string Placa { get; set; } = null!;
        public string? TarjetaOperativa { get; set; }
        public TipoUbDTO TipoUb { get; set; }
        public string? Ano { get; set; }
        public BlindadorDTO Blindador { get; set; }
        public ModeloDTO Modelo { get; set; }
        public EstadoUbDto EstadoUb { get; set; }
    }
}
