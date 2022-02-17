using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using etvApi.Models;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/EstadoUbs")]
    public class EstadoUbController
    {
        private readonly etvContext _context;

        public EstadoUbController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstadoUb>>> Get()
        {
            var data = await _context.EstadoUbs.ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(EstadoUb estadoUb)
        {
            _context.EstadoUbs.Add(estadoUb);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] EstadoUb estadoUb)
        {
            if (estadoUb.IdEstadoUb != id)
            {
                return BadRequest("El id del EstadoUb no coincide con el id de la URL");
            }

            var existe = await _context.EstadoUbs.AnyAsync(x => x.IdEstadoUb == id);
            if (!existe)
            {
                return NotFound();
            }

            _context.Update(estadoUb);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private ActionResult BadRequest(string v)
        {
            throw new NotImplementedException();
        }

        private ActionResult NotFound()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.EstadoUbs.AnyAsync(x => x.IdEstadoUb == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new EstadoUb() { IdEstadoUb = id });
            await _context.SaveChangesAsync();
            return Ok();
        }

        private ActionResult Ok()
        {
            throw new NotImplementedException();
        }
    }
}
