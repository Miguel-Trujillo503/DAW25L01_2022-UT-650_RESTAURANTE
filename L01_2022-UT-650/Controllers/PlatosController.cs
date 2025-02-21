using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L01_2022_UT_650.Data;
using L01_2022_UT_650.Models;

namespace L01_2022_UT_650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatosController : ControllerBase
    {
        private readonly RestauranteDbContext _context;

        public PlatosController(RestauranteDbContext context)
        {
            _context = context;
        }

        // GET: api/Platos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plato>>> GetPlatos()
        {
            return await _context.Platos.ToListAsync();
        }

        // GET: api/Platos/Filtrar?nombre=pizza
        [HttpGet("Filtrar")]
        public async Task<ActionResult<IEnumerable<Plato>>> FiltrarPlatosPorNombre(string nombre)
        {
            return await _context.Platos
                .Where(p => p.NombrePlato.Contains(nombre))
                .ToListAsync();
        }

        // POST, PUT y DELETE se generan automáticamente con el scaffolding.
    }
}
