using Etv.entities.Modelos;
using etvApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/OtDetalles")]
    public class OtDetalleController : ControllerBase
    {
        private readonly etvContext _context;

        public OtDetalleController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<OtDetalle>>> Get()
        {
            var data = await _context.OtDetalles.ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(OtDetalle otDetalle)
        {
            _context.OtDetalles.Add(otDetalle);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] OtDetalle otDetalle)
        {
            if (otDetalle.IdOt != id)
            {
                return BadRequest("El id del OtDetalle no coincide con el id de la URL");
            }

            var existe = await _context.OtDetalles.AnyAsync(x => x.IdOt == id);
            if (!existe)
            {
                return NotFound();
            }

            _context.Update(otDetalle);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.OtDetalles.AnyAsync(x => x.IdOt == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new OtDetalle() { IdOt = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
