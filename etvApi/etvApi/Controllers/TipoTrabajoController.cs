using etvApi.Data;
using etvApi.Models;
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
            var data = await _context.TipoTrabajos.ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(TipoTrabajo tipoTrabajo)
        {
            _context.TipoTrabajos.Add(tipoTrabajo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoTrabajo tipoTrabajo)
        {
            if (tipoTrabajo.IdTipoTrabajo != id)
            {
                return BadRequest("El id del TipoTrabajo no coincide con el id de la URL");
            }

            var existe = await _context.TipoTrabajos.AnyAsync(x => x.IdTipoTrabajo == id);
            if (!existe)
            {
                return NotFound();
            }

            _context.Update(tipoTrabajo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.TipoTrabajos.AnyAsync(x => x.IdTipoTrabajo == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new TipoTrabajo() { IdTipoTrabajo = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

