namespace etvApi.DTOS
{
    public class PersonaDTO
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; } = null!;
        public string? APaterno { get; set; }
        public string? AMaterno { get; set; }
        public bool Estado { get; set; }
        public int IdCargo { get; set; }
    }
}
