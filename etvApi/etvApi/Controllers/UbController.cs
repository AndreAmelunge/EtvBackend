using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using etvApi.Models;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/Ubs")]
    public class UbController : ControllerBase
    {
        private readonly etvContext _context;

        public UbController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ub>>> Get()
        {
            var data = await _context.Ubs.ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Ub ub)
        {
            _context.Ubs.Add(ub);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Ub ub)
        {
            if (ub.IdUb != id)
            {
                return BadRequest("El id del Ub no coincide con el id de la URL");
            }

            var existe = await _context.Ubs.AnyAsync(x => x.IdUb == id);
            if (!existe)
            {
                return NotFound();
            }

            _context.Update(ub);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Ubs.AnyAsync(x => x.IdUb == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new Ub() { IdUb = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
