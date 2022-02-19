using Etv.entities.Modelos;
using etvApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/Rols")]
    public class RolController : ControllerBase
    {
        private readonly etvContext _context;

        public RolController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rol>>> Get()
        {
            var data = await _context.Rols.Where(q => q.Estado).ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Rol rol)
        {
            rol.Estado = true;
            _context.Rols.Add(rol);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Rol rol)
        {
            if (rol.IdRol != id)
            {
                return BadRequest("El id del rol no coincide con el id de la URL");
            }

            var existe = await _context.Rols.AnyAsync(x => x.IdRol == id);
            if (!existe)
            {
                return NotFound();
            }
            rol.Estado = true;
            _context.Update(rol);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Rols.FirstOrDefaultAsync(x => x.IdRol == id);
            if (existe == null)
            {
                return NotFound();
            }
            existe.Estado = false;
            _context.Update(existe);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
