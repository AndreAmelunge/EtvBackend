using Etv.entities.DTOS;
using etvApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly etvContext _context;
        public ReportController(etvContext context)
        {
            _context = context;
        }

        [HttpGet("{idOt}")]
        public async Task<ActionResult<ReportDTO>> GetById(int idOt)
        {
            ReportDTO report = new ReportDTO();
            var data = await _context.Ots
                .Include(q => q.IdSucursalNavigation)
                .Include(q => q.IdPersonaNavigation)
                .Include(q=>q.IdTipoTrabajoNavigation)
                .Include(q => q.OtDetalle)
                .ThenInclude(p => p.IdUbNavigation)
                .ThenInclude(p => p.IdModeloNavigation)
                .ThenInclude(p => p.IdMarcaNavigation)
                .Where(q => q.IdOt == idOt).FirstOrDefaultAsync();
            report.Sucursal = new SucursalReport
            {
                Nombre = data.IdSucursalNavigation.Nombre,
                Sigla = data.IdSucursalNavigation.Sigla
            };
            var nombrePersona = data.IdPersonaNavigation;
            report.Choferdesignado = nombrePersona.Nombre+" "+nombrePersona.APaterno + " " + nombrePersona.AMaterno;
            report.TipoTrabajo = data.IdTipoTrabajoNavigation.Nombre;
            report.Vehiculo = new Vehiculo
            {
                Marca = data.OtDetalle.IdUbNavigation.IdModeloNavigation.IdMarcaNavigation.Nombre,
                NumeroPlaca = data.OtDetalle.IdUbNavigation.Placa,
                UB_VEHICULO_CUENTA = data.OtDetalle.IdUbNavigation.Codigo
            };
            report.Detalle = new Detalle
            {
                Codigo = data.Codigo,
                Trabajosolicitado = data.OtDetalle.TrabajoSolicitado,
                Descripcion = data.OtDetalle.Descripcion,
                Precio = data.OtDetalle.Precio
            };
            return report;

            //List<OtResponceDTO> lst = new List<OtResponceDTO>();
            //foreach (var item in data)
            //{
            //    OtResponceDTO obj = new OtResponceDTO
            //    {
            //        Ot = new OtDTO
            //        {
            //            IdOt = item.IdOt,
            //            Codigo = item.Codigo,
            //            FechaSolicitud = item.FechaSolicitud,
            //        },
            //        otDetalle = new OtDetalleDTO
            //        {
            //            TrabajoSolicitado = item.OtDetalle.TrabajoSolicitado,
            //            Descripcion = item.OtDetalle.Descripcion,
            //            Precio = item.OtDetalle.Precio,
            //            IdUb = item.OtDetalle.IdUb
            //        }
            //    };
            //    var ub = await _context.Ubs
            //        .Include(q => q.IdTipoUbNavigation)
            //        .Include(q => q.EstadoUbNavigation)
            //        .Include(q => q.IdModeloNavigation)
            //        .Include(q => q.IdBlindadorNavigation)
            //        .SingleOrDefaultAsync(q => q.IdUb == item.OtDetalle.IdUb);
            //    obj.Ub = new UbResponceDto
            //    {
            //        IdUb = ub.IdUb,
            //        Codigo = ub.Codigo,
            //        Placa = ub.Placa,
            //        TipoUb = new TipoUbDTO
            //        {
            //            IdTipoUb = ub.IdTipoUbNavigation.IdTipoUb,
            //            Nombre = ub.IdTipoUbNavigation.Nombre,
            //        },
            //        Ano = ub.Ano,
            //        Blindador = new BlindadorDTO
            //        {
            //            IdBlindador = ub.IdBlindadorNavigation.IdBlindador,
            //            Nombre = ub.IdBlindadorNavigation.Nombre
            //        },
            //        Modelo = new ModeloDTO
            //        {
            //            IdModelo = ub.IdModeloNavigation.IdModelo,
            //            Nombre = ub.IdModeloNavigation.Nombre,
            //        },
            //        EstadoUb = new EstadoUbDto
            //        {
            //            IdEstadoUb = ub.EstadoUbNavigation.IdEstadoUb,
            //            Nombre = ub.EstadoUbNavigation.Nombre
            //        }
            //    };
            //    lst.Add(obj);
            //}
            //return lst;
        }
    }
}
