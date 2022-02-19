using Etv.entities.Modelos;
using etvApi.Data;
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
            var data = await _context.Blindadors.Where(q => q.Estado).ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Blindador blindador)
        {
            blindador.Estado = true;
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
            blindador.Estado = true;
            _context.Update(blindador);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Blindadors.FirstOrDefaultAsync(x => x.IdBlindador == id);
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

