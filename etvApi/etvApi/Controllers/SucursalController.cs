using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using etvApi.Models;
using etvApi.DTOS;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/Sucursals")]
    public class SucursalController : ControllerBase
    {
        private readonly etvContext _context;

        public SucursalController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sucursal>>> Get()
        {
            var data = await _context.Sucursals.ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(SucursalDTO sucursalDTO)
        {
            var data = new Sucursal
            {
                Nombre = sucursalDTO.Nombre,
                Sigla = sucursalDTO.Sigla,
                Estado = true,
            };
            _context.Sucursals.Add(data);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Sucursal sucursal)
        {
            var existe = await _context.Sucursals.AnyAsync(x => x.IdSucursal == id);
            if (!existe)
            {
                return NotFound();
            }

            _context.Update(sucursal);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Sucursals.AnyAsync(x => x.IdSucursal == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new Sucursal() { IdSucursal = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
