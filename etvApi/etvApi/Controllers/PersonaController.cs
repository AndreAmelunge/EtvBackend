using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using etvApi.Models;

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
            var data = await _context.Personas.ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Persona persona)
        {
            if (persona.IdPersona != id)
            {
                return BadRequest("El id del Persona no coincide con el id de la URL");
            }

            var existe = await _context.Personas.AnyAsync(x => x.IdPersona == id);
            if (!existe)
            {
                return NotFound();
            }

            _context.Update(persona);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Personas.AnyAsync(x => x.IdPersona == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new Persona() { IdPersona = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
