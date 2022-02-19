using Etv.entities.DTOS;
using Etv.entities.Modelos;
using etvApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly etvContext _context;
        public UsuarioController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            var data = await _context.Usuarios
                .Include(q => q.IdPersonaNavigation)
                .Include(q => q.IdRolNavigation)
                .Include(q => q.IdSucursalNavigation).Where(q => q.Estado).ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(UsuarioDTO usuario)
        {
            var existeUsuarioPorPersona = await _context.Usuarios.SingleOrDefaultAsync(q => q.IdPersona == usuario.IdPersona && q.Estado);
            if (existeUsuarioPorPersona != null)
                return BadRequest("La persona seleccionada ya tiene un usuario asignado");
            var existeUsuario = await _context.Usuarios.SingleOrDefaultAsync(q => q.Nombre == usuario.Nombre && q.Estado);
            if (existeUsuario != null)
                return BadRequest("Existe un usuario con el mismo nombre, asignar otro usuario");
            var obj = new Usuario
            {
                IdPersona = usuario.IdPersona,
                Nombre = usuario.Nombre,
                Contrasena = usuario.Contrasena,
                IdRol = usuario.IdRol,
                IdSucursal = usuario.IdSucursal,
                Estado = true
            };
            _context.Usuarios.Add(obj);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioDTO usuario)
        {
            var existe = await _context.Usuarios.FirstOrDefaultAsync(x => x.IdPersona == id);
            if (existe == null)
            {
                return NotFound();
            }
            existe.Nombre = usuario.Nombre;
            existe.Contrasena = usuario.Contrasena;
            existe.IdRol = usuario.IdRol;
            existe.IdSucursal = usuario.IdSucursal;
            existe.Estado = true;
            _context.Update(existe);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Usuarios.FirstOrDefaultAsync(x => x.IdPersona == id);
            if (existe == null)
            {
                return NotFound();
            }
            _context.Remove(existe);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

