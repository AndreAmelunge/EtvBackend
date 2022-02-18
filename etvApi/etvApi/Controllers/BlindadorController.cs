using etvApi.Data;
using etvApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/blindadors")]

    public class BlindadorController : ControllerBase
    {
        private readonly etvContext _context;

        public BlindadorController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Blindador>>> Get()
        {
            var data = await _context.Blindadors.ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Blindador blindador)
        {
            _context.Blindadors.Add(blindador);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Blindador blindador)
        {
            if (blindador.IdBlindador != id)
            {
                return BadRequest("El id del blindador no coincide con el id de la URL");
            }

            var existe = await _context.Blindadors.AnyAsync(x => x.IdBlindador == id);
            if (!existe)
            {
                return NotFound();
            }

            _context.Update(blindador);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Blindadors.AnyAsync(x => x.IdBlindador == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new Blindador() { IdBlindador = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

