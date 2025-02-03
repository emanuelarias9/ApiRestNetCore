using ApiRestNetCore.Context;
using ApiRestNetCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ApiRestNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Persona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            return await _context.Personas.ToListAsync();
        }

        // GET: api/Persona/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var Persona = await _context.Personas.FindAsync(id);

            if (Persona == null)
            {
                return NotFound();
            }

            return Persona;
        }

        // PUT: api/Persona/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona Persona)
        {
            if (id != Persona.Id)
            {
                return BadRequest();
            }

            _context.Entry(Persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Persona
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona Persona)
        {
            _context.Personas.Add(Persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = Persona.Id }, Persona);
        }

        // DELETE: api/Persona/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var Persona = await _context.Personas.FindAsync(id);
            if (Persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(Persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }
    }
}