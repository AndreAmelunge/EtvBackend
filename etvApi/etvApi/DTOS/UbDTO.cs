namespace etvApi.DTOS
{
    public class UbDTO
    {
        public int IdUb { get; set; }
        public string Codigo { get; set; } = null!;
        public string Placa { get; set; } = null!;
        public string? TarjetaOperativa { get; set; }
        public int IdTipoUb { get; set; }
        public string? Ano { get; set; }
        public int IdBlindador { get; set; }
        public int IdModelo { get; set; }
        public int EstadoUb { get; set; }
    }
}
