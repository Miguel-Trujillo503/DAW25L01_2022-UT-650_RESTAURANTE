using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L01_2022_UT_650.Data;
using L01_2022_UT_650.Models;

namespace L01_2022_UT_650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoristasController : ControllerBase
    {
        private readonly RestauranteDbContext _context;

        public MotoristasController(RestauranteDbContext context)
        {
            _context = context;
        }

        // GET: api/Motoristas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motorista>>> GetMotoristas()
        {
            return await _context.Motoristas.ToListAsync();
        }

        // GET: api/Motoristas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Motorista>> GetMotorista(int id)
        {
            var motorista = await _context.Motoristas.FindAsync(id);

            if (motorista == null)
            {
                return NotFound();
            }

            return motorista;
        }

        // POST: api/Motoristas
        [HttpPost]
        public async Task<ActionResult<Motorista>> PostMotorista(Motorista motorista)
        {
            _context.Motoristas.Add(motorista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotorista", new { id = motorista.MotoristaId }, motorista);
        }

        // PUT: api/Motoristas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotorista(int id, Motorista motorista)
        {
            if (id != motorista.MotoristaId)
            {
                return BadRequest();
            }

            _context.Entry(motorista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoristaExists(id))
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

        // DELETE: api/Motoristas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotorista(int id)
        {
            var motorista = await _context.Motoristas.FindAsync(id);
            if (motorista == null)
            {
                return NotFound();
            }

            _context.Motoristas.Remove(motorista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotoristaExists(int id)
        {
            return _context.Motoristas.Any(e => e.MotoristaId == id);
        }
    }
}
