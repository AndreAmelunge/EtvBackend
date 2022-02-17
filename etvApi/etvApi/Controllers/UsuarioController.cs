using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using etvApi.Models;
using Etv.BL;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly etvContext _context;
        private readonly UserBL _userBL;

        public UsuarioController(etvContext context)
        {
            _context = context;
            _userBL = new UserBL();
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            var data = await _context.Usuarios.ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Usuario usuario)
        {
            if (usuario.IdUsuario != id)
            {
                return BadRequest("El id del Usuario no coincide con el id de la URL");
            }

            var existe = await _context.Usuarios.AnyAsync(x => x.IdUsuario == id);
            if (!existe)
            {
                return NotFound();
            }

            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Usuarios.AnyAsync(x => x.IdUsuario == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new Usuario() { IdUsuario = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

