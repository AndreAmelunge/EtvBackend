using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using etvApi.Models;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/Ots")]
    public class OtController : ControllerBase
    {
        private readonly etvContext _context;

        public OtController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ot>>> Get()
        {
            var data = await _context.Ots.ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Ot ot)
        {
            _context.Ots.Add(ot);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Ot ot)
        {
            if (ot.IdOt != id)
            {
                return BadRequest("El id del ot no coincide con el id de la URL");
            }

            var existe = await _context.Ots.AnyAsync(x => x.IdOt == id);
            if (!existe)
            {
                return NotFound();
            }

            _context.Update(ot);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Ots.AnyAsync(x => x.IdOt == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new Ot() { IdOt = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
