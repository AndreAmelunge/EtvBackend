using etvApi.Data;
using etvApi.DTOS;
using etvApi.Models;
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
                .Include(q => q.EstadoUbNavigation).ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(UbDTO ub)
        {
            Ub obj = new Ub();
            obj.Codigo = ub.Codigo;
            obj.Placa = ub.Placa;
            obj.TarjetaOperativa = ub.TarjetaOperativa;
            obj.IdTipoUb = ub.IdTipoUb;
            obj.Ano = ub.Ano;
            obj.IdBlindador = ub.IdBlindador;
            obj.IdModelo = ub.IdModelo;
            obj.EstadoUb = ub.EstadoUb;
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
            _context.Update(existe);
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
