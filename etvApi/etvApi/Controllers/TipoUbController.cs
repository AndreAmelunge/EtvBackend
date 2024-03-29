﻿using Etv.entities.Modelos;
using etvApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/TipoUbs")]
    public class TipoUbController : ControllerBase
    {
        private readonly etvContext _context;

        public TipoUbController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoUb>>> Get()
        {
            var data = await _context.TipoUbs.Where(q => q.Estado).ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(TipoUb tipoUb)
        {
            tipoUb.Estado = true;
            _context.TipoUbs.Add(tipoUb);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoUb tipoUb)
        {
            if (tipoUb.IdTipoUb != id)
            {
                return BadRequest("El id del TipoUb no coincide con el id de la URL");
            }

            var existe = await _context.TipoUbs.AnyAsync(x => x.IdTipoUb == id);
            if (!existe)
            {
                return NotFound();
            }
            tipoUb.Estado = true;
            _context.Update(tipoUb);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.TipoUbs.FirstOrDefaultAsync(x => x.IdTipoUb == id);
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
