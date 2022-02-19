using Etv.entities.Modelos;
using etvApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/Marcas")]
    public class MarcaController : ControllerBase
    {
        private readonly etvContext _context;

        public MarcaController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Marca>>> Get()
        {
            var data = await _context.Marcas.Where(q => q.Estado).ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Marca marca)
        {
            marca.Estado = true;
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Marca marca)
        {
            if (marca.IdMarca != id)
            {
                return BadRequest("El id del marca no coincide con el id de la URL");
            }

            var existe = await _context.Marcas.AnyAsync(x => x.IdMarca == id);
            if (!existe)
            {
                return NotFound();
            }
            marca.Estado = true;
            _context.Update(marca);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Marcas.FirstOrDefaultAsync(x => x.IdMarca == id);
            if (existe == null)
            {
                return NotFound();
            }
            //_context.Remove(new Marca() { IdMarca = id });
            existe.Estado = false;
            _context.Update(existe);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
