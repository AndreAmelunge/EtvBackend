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
            var data = await _context.Ots
                .Include(q => q.IdSucursalNavigation)
                .Include(q => q.IdTipoTrabajoNavigation)
                .Include(q => q.IdPersonaNavigation).ToListAsync();

            return data;
        }

        [HttpGet("{idOt}")]
        public async Task<ActionResult<List<OtResponceDTO>>> GetById(int idOt)
        {
            List<OtResponceDTO> lst = new List<OtResponceDTO>();
            var data = await _context.Ots
                .Include(q => q.IdSucursalNavigation)
                .Include(q => q.IdTipoTrabajoNavigation)
                .Include(q => q.IdPersonaNavigation)
                .Include(q => q.OtDetalle).ToListAsync();
            foreach (var item in data)
            {
                OtResponceDTO obj = new OtResponceDTO
                {
                    Ot = new OtDTO
                    {
                        IdOt = item.IdOt,
                        Codigo = item.Codigo,
                        FechaSolicitud = item.FechaSolicitud,
                        PrecioTotal = item.PrecioTotal,
                        IdSucursal = item.IdSucursal,
                        IdTipoTrabajo = item.IdTipoTrabajo,
                        IdPersona = item.IdPersona
                    },
                    otDetalle = new OtDetalleDTO
                    {
                        TrabajoSolicitado = item.OtDetalle.TrabajoSolicitado,
                        Descripcion = item.OtDetalle.Descripcion,
                        Precio = item.OtDetalle.Precio,
                        IdUb = item.OtDetalle.IdUb
                    }
                };
                var ub = await _context.Ubs
                    .Include(q => q.IdTipoUbNavigation)
                    .Include(q => q.EstadoUbNavigation)
                    .Include(q => q.IdModeloNavigation)
                    .Include(q => q.IdBlindadorNavigation)
                    .SingleOrDefaultAsync(q => q.IdUb == item.OtDetalle.IdUb);
                obj.Ub = new UbResponceDto
                {
                    IdUb = ub.IdUb,
                    Codigo = ub.Codigo,
                    Placa = ub.Placa,
                    TarjetaOperativa = ub.TarjetaOperativa,
                    TipoUb = new TipoUbDTO
                    {
                        IdTipoUb = ub.IdTipoUbNavigation.IdTipoUb,
                        Nombre = ub.IdTipoUbNavigation.Nombre,
                    },
                    Ano = ub.Ano,
                    Blindador = new BlindadorDTO
                    {
                        IdBlindador = ub.IdBlindadorNavigation.IdBlindador,
                        Nombre = ub.IdBlindadorNavigation.Nombre
                    },
                    Modelo = new ModeloDTO
                    {
                        IdModelo = ub.IdModeloNavigation.IdModelo,
                        Nombre = ub.IdModeloNavigation.Nombre,
                    },
                    EstadoUb = new EstadoUbDto
                    {
                        IdEstadoUb = ub.EstadoUbNavigation.IdEstadoUb,
                        Nombre = ub.EstadoUbNavigation.Nombre
                    }
                };
                lst.Add(obj);
            }
            return lst;
        }

        [HttpPost]
        public async Task<ActionResult> Post(OtRegistroDTO otDto)
        {
            try
            {
                var otDetalle = new OtDetalle
                {
                    IdOt = 1,
                    TrabajoSolicitado = otDto.otDetalle.TrabajoSolicitado,
                    Descripcion = otDto.otDetalle.Descripcion,
                    Precio = otDto.otDetalle.Precio,
                    IdUb = otDto.otDetalle.IdUb,
                };
                var ot = new Ot
                {
                    Codigo = otDto.Ot.Codigo,
                    FechaSolicitud = otDto.Ot.FechaSolicitud,
                    PrecioTotal = otDto.Ot.PrecioTotal,
                    IdSucursal = otDto.Ot.IdSucursal,
                    IdTipoTrabajo = otDto.Ot.IdTipoTrabajo,
                    IdPersona = otDto.Ot.IdPersona,
                    OtDetalle = otDetalle
                };
                //_context.OtDetalles.Add(otDetalle);
                //var id = await _context.SaveChangesAsync();

                _context.Ots.Add(ot);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

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
            try
            {
                var existe = await _context.Ots.AnyAsync(x => x.IdOt == id);
                if (!existe)
                {
                    return NotFound();
                }
                _context.Remove(new Ot() { IdOt = id });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Ok();
        }
    }
}
