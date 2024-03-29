﻿using Etv.entities.DTOS;
using Etv.entities.Modelos;
using etvApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var data = await _context.Sucursals.Where(q => q.Estado).ToListAsync();
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
            sucursal.Estado = true;
            _context.Update(sucursal);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Sucursals.FirstOrDefaultAsync(x => x.IdSucursal == id);
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
