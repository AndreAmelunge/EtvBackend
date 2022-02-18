using etvApi.Data;
using etvApi.DTOS;
using etvApi.Models;
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
            return await _context.Modelos.Include(q => q.IdMarcaNavigation).ToListAsync();
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
            _context.Update(existe);
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
