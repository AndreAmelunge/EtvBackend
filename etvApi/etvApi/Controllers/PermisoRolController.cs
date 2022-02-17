using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using etvApi.Models;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/PermisoRols")]
    public class PermisoRolController : ControllerBase
    {
        private readonly etvContext _context;

        public PermisoRolController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PermisoRol>>> Get()
        {
            var data = await _context.PermisoRols.ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(PermisoRol permisoRol)
        {
            _context.PermisoRols.Add(permisoRol);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] PermisoRol permisoRol)
        {
            if (permisoRol.IdPermisoRol != id)
            {
                return BadRequest("El id del PermisoRol no coincide con el id de la URL");
            }

            var existe = await _context.PermisoRols.AnyAsync(x => x.IdPermisoRol == id);
            if (!existe)
            {
                return NotFound();
            }

            _context.Update(permisoRol);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.PermisoRols.AnyAsync(x => x.IdPermisoRol == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new PermisoRol() { IdPermisoRol = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
