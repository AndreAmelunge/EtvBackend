using etvApi.DTOS;
using etvApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace etvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly etvContext _context;
        public TokenController(etvContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginDTO dto)
        {
            //var oUsuario = await _context.Usuarios.FirstOrDefaultAsync(q => q.Nombre == dto.Usuario && q.Contrasena == dto.Password);
            //if (oUsuario == null)
            //    return NotFound("el usuario no existe");
            if (!dto.Usuario.Equals("pepe"))
                return NotFound("el usuario no existe");
            var oUsuario = new Usuario
            {
                Nombre = "pepe",  
                IdRol = 1,
            };
            string token = CreateToken(oUsuario);
            var json = new
            {
                token,
                usuario = oUsuario
            };
            return Ok(json);
        }

        private string CreateToken(Usuario usuario)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Role, usuario.IdRol.ToString()),
            };

            var Key = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:key").Value));

            var cred = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
