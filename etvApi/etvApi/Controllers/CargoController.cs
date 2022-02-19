using Etv.entities.Modelos;
using etvApi.Data;
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
            var data = await _context.Cargos.Where(q => q.Estado).ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Cargo cargo)
        {
            cargo.Estado = true;
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
            cargo.Estado = true;
            _context.Update(cargo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Cargos.FirstOrDefaultAsync(x => x.IdCargo == id);
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
