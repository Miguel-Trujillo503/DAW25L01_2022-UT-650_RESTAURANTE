using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L01_2022_UT_650.Data;
using L01_2022_UT_650.Models;

namespace L01_2022_UT_650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly RestauranteDbContext _context;

        public ClientesController(RestauranteDbContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Clientes/Filtrar?direccion=centro
        [HttpGet("Filtrar")]
        public async Task<ActionResult<IEnumerable<Cliente>>> FiltrarClientesPorDireccion(string direccion)
        {
            return await _context.Clientes
                .Where(c => c.Direccion.Contains(direccion))
                .ToListAsync();
        }

        // GET: api/Clientes/TopN?cantidad=3
        [HttpGet("TopN")]
        public async Task<ActionResult<IEnumerable<object>>> TopClientesPorPedidos(int cantidad)
        {
            var topClientes = await _context.Pedidos
                .GroupBy(p => p.ClienteId)
                .Select(g => new
                {
                    ClienteId = g.Key,
                    TotalPedidos = g.Count(),
                    Cliente = _context.Clientes.FirstOrDefault(c => c.ClienteId == g.Key)
                })
                .OrderByDescending(g => g.TotalPedidos)
                .Take(cantidad)
                .ToListAsync();

            return Ok(topClientes);
        }

        // POST, PUT y DELETE se generan automáticamente con el scaffolding.
    }
}
