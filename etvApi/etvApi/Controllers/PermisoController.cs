using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using etvApi.Models;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/Permisos")]
    public class PermisoController : ControllerBase
    {
        private readonly etvContext _context;

        public PermisoController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Permiso>>> Get()
        {
            var data = await _context.Permisos.ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Permiso permiso)
        {
            _context.Permisos.Add(permiso);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Permiso permiso)
        {
            if (permiso.IdPermiso != id)
            {
                return BadRequest("El id del permiso no coincide con el id de la URL");
            }

            var existe = await _context.Permisos.AnyAsync(x => x.IdPermiso == id);
            if (!existe)
            {
                return NotFound();
            }

            _context.Update(permiso);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Permisos.AnyAsync(x => x.IdPermiso == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new Permiso() { IdPermiso = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
