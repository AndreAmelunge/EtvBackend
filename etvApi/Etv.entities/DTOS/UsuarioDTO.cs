namespace Etv.entities.DTOS
{
    public class UsuarioDTO
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public int IdRol { get; set; }
        public int IdSucursal { get; set; }
    }
}
