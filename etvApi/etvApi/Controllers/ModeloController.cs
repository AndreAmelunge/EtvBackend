using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using etvApi.Models;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/Modelos")]
    public class ModeloController : ControllerBase
    {
        private readonly etvContext _context;

        public ModeloController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Modelo>>> Get()
        {
            var data = await _context.Modelos.ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Modelo modelo)
        {
            _context.Modelos.Add(modelo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Modelo modelo)
        {
            if (modelo.IdModelo != id)
            {
                return BadRequest("El id del modelo no coincide con el id de la URL");
            }

            var existe = await _context.Modelos.AnyAsync(x => x.IdModelo == id);
            if (!existe)
            {
                return NotFound();
            }

            _context.Update(modelo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Modelos.AnyAsync(x => x.IdModelo == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new Modelo() { IdModelo = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
