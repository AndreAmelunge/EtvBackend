using Etv.entities.DTOS;
using Etv.entities.Modelos;
using etvApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return await _context.Modelos.Include(q => q.IdMarcaNavigation).Where(q => q.Estado).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(ModeloDTO modelo)
        {
            var obj = new Modelo
            {
                Nombre = modelo.Nombre,
                Estado = true,
                IdMarca = modelo.IdMarca
            };
            _context.Modelos.Add(obj);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ModeloDTO modelo)
        {
            var existe = await _context.Modelos.FirstOrDefaultAsync(x => x.IdModelo == id);
            if (existe == null)
                return NotFound();

            existe.Nombre = modelo.Nombre;
            existe.IdMarca = modelo.IdMarca;
            existe.Estado = true;
            _context.Update(existe);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Modelos.FirstOrDefaultAsync(x => x.IdModelo == id);
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
