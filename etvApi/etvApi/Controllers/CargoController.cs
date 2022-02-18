using etvApi.Data;
using etvApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/cargos")]
    public class CargoController : ControllerBase
    {
        private readonly etvContext _context;

        public CargoController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cargo>>> Get()
        {
            var data = await _context.Cargos.ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Cargo cargo)
        {
            _context.Cargos.Add(cargo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Cargo cargo)
        {
            if (cargo.IdCargo != id)
            {
                return BadRequest("El id del cargo no coincide con el id de la URL");
            }

            var existe = await _context.Cargos.AnyAsync(x => x.IdCargo == id);
            if (!existe)
            {
                return NotFound();
            }

            _context.Update(cargo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Cargos.AnyAsync(x => x.IdCargo == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new Cargo() { IdCargo = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
