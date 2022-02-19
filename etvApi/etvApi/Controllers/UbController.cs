using Etv.entities.DTOS;
using Etv.entities.Modelos;
using etvApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var data = await _context.Ubs
                .Include(q => q.IdTipoUbNavigation)
                .Include(q => q.IdBlindadorNavigation)
                .Include(q => q.IdModeloNavigation)
                .Include(q => q.EstadoUbNavigation)
                .Where(q => q.Estado).ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(UbDTO ub)
        {
            Ub obj = new()
            {
                Codigo = ub.Codigo,
                Placa = ub.Placa,
                TarjetaOperativa = ub.TarjetaOperativa,
                IdTipoUb = ub.IdTipoUb,
                Ano = ub.Ano,
                IdBlindador = ub.IdBlindador,
                IdModelo = ub.IdModelo,
                EstadoUb = ub.EstadoUb,
                Estado = true
            };
            _context.Ubs.Add(obj);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] UbDTO ub)
        {
            var existe = await _context.Ubs.FirstOrDefaultAsync(x => x.IdUb == id);
            if (existe == null)
                return NotFound();

            existe.Codigo = ub.Codigo;
            existe.Placa = ub.Placa;
            existe.TarjetaOperativa = ub.TarjetaOperativa;
            existe.IdTipoUb = ub.IdTipoUb;
            existe.Ano = ub.Ano;
            existe.IdBlindador = ub.IdBlindador;
            existe.IdModelo = ub.IdModelo;
            existe.EstadoUb = ub.EstadoUb;
            existe.Estado = true;
            _context.Update(existe);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Ubs.FirstOrDefaultAsync(x => x.IdUb == id);
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
