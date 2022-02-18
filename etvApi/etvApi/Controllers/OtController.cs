using etvApi.Data;
using etvApi.DTOS;
using etvApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult> Post(OtRegistroDTO otDto)
        {
            var ot = new Ot
            {
                Codigo = otDto.Ot.Codigo,
                FechaSolicitud = otDto.Ot.FechaSolicitud,
                PrecioTotal = otDto.Ot.PrecioTotal,
                IdSucursal = otDto.Ot.IdSucursal,
                IdTipoTrabajo = otDto.Ot.IdTipoTrabajo,
                IdPersona = otDto.Ot.IdPersona,
            };
            _context.Ots.Add(ot);
            var id = await _context.SaveChangesAsync();
            var otDetalle = new OtDetalle
            {
                IdOt = id,
                TrabajoSolicitado = otDto.otDetalle.TrabajoSolicitado,
                Descripcion = otDto.otDetalle.Descripcion,
                Precio = otDto.otDetalle.Precio,
                IdUb = otDto.otDetalle.IdUb,
            };
            _context.OtDetalles.Add(otDetalle);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] OtRegistroDTO otDto)
        {
            var existeOt = await _context.Ots.FirstOrDefaultAsync(x => x.IdOt == id);
            if (existeOt == null)
                return NotFound();
            existeOt.Codigo = otDto.Ot.Codigo;
            existeOt.FechaSolicitud = otDto.Ot.FechaSolicitud;
            existeOt.PrecioTotal = otDto.Ot.PrecioTotal;
            existeOt.IdSucursal = otDto.Ot.IdSucursal;
            existeOt.IdTipoTrabajo = otDto.Ot.IdTipoTrabajo;
            existeOt.IdPersona = otDto.Ot.IdPersona;
            _context.Update(existeOt);

            var existeOtDetalle = await _context.OtDetalles.FirstOrDefaultAsync(x => x.IdOt == id);
            if (existeOtDetalle == null)
                return NotFound();
            existeOtDetalle.TrabajoSolicitado = otDto.otDetalle.TrabajoSolicitado;
            existeOtDetalle.Descripcion = otDto.otDetalle.Descripcion;
            existeOtDetalle.Precio = otDto.otDetalle.Precio;
            existeOtDetalle.IdUb = otDto.otDetalle.IdUb;
            _context.Update(existeOtDetalle);
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
