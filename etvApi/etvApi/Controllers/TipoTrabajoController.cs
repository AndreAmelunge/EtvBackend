using Etv.entities.DTOS;
using Etv.entities.Modelos;
using etvApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/TipoTranajos")]
    public class TipoTrabajoController : ControllerBase
    {
        private readonly etvContext _context;

        public TipoTrabajoController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoTrabajo>>> Get()
        {
            var data = await _context.TipoTrabajos.Where(q => q.Estado).ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(TipoTrabajo tipoTrabajo)
        {
            tipoTrabajo.Estado = true;
            _context.TipoTrabajos.Add(tipoTrabajo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoTrabajoDTO tipoTrabajo)
        {
            if (tipoTrabajo.IdTipoTrabajo != id)
            {
                return BadRequest("El id del TipoTrabajo no coincide con el id de la URL");
            }

            var existe = await _context.TipoTrabajos.FirstOrDefaultAsync(x => x.IdTipoTrabajo == id);
            if (existe == null)
            {
                return NotFound();
            }
            existe.Nombre = tipoTrabajo.Nombre;
            existe.Estado = true;
            _context.Update(existe);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.TipoTrabajos.FirstOrDefaultAsync(x => x.IdTipoTrabajo == id);
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

