using Etv.entities.DTOS;
using Etv.entities.Modelos;
using etvApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/EstadoUbs")]
    public class EstadoUbController : ControllerBase
    {
        private readonly etvContext _context;

        public EstadoUbController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstadoUb>>> Get()
        {
            var data = await _context.EstadoUbs.Where(q => q.Estado).ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(EstadoUb estadoUb)
        {
            estadoUb.Estado = true;
            _context.EstadoUbs.Add(estadoUb);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] EstadoUbDto estadoUb)
        {
            if (estadoUb.IdEstadoUb != id)
            {
                return BadRequest("El id del EstadoUb no coincide con el id de la URL");
            }

            var existe = await _context.EstadoUbs.FirstOrDefaultAsync(x => x.IdEstadoUb == id);
            if (existe == null)
            {
                return NotFound();
            }
            existe.Nombre = estadoUb.Nombre;
            existe.Estado = true;
            _context.Update(existe);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.EstadoUbs.FirstOrDefaultAsync(x => x.IdEstadoUb == id);
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
