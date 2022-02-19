using Etv.entities.DTOS;
using Etv.entities.Modelos;
using etvApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etvApi.Controllers
{
    [ApiController]
    [Route("api/Personas")]
    public class PersonaController : ControllerBase
    {
        private readonly etvContext _context;

        public PersonaController(etvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            var data = await _context.Personas.Include(q => q.IdCargoNavigation).Where(q => q.Estado).ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(PersonaDTO persona)
        {
            var obj = new Persona
            {
                Nombre = persona.Nombre,
                APaterno = persona.APaterno,
                AMaterno = persona.AMaterno,
                Estado = true,
                IdCargo = persona.IdCargo
            };
            _context.Personas.Add(obj);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] PersonaDTO persona)
        {
            var existe = await _context.Personas.FirstOrDefaultAsync(x => x.IdPersona == id);
            if (existe == null)
            {
                return NotFound();
            }

            existe.Nombre = persona.Nombre;
            existe.APaterno = persona.APaterno;
            existe.AMaterno = persona.AMaterno;
            existe.IdCargo = persona.IdCargo;
            existe.Estado = true;
            _context.Update(existe);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Personas.FirstOrDefaultAsync(x => x.IdPersona == id);
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
