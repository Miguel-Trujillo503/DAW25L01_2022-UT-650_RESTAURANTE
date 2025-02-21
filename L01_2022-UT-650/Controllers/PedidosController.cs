using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L01_2022_UT_650.Data;
using L01_2022_UT_650.Models;

namespace L01_2022_UT_650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly RestauranteDbContext _context;

        public PedidosController(RestauranteDbContext context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Motorista)
                .Include(p => p.Plato)
                .ToListAsync();
        }

        // GET: api/Pedidos/PorCliente?id=1
        [HttpGet("PorCliente")]
        public async Task<ActionResult<IEnumerable<Pedido>>> FiltrarPedidosPorCliente(int id)
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Motorista)
                .Include(p => p.Plato)
                .Where(p => p.ClienteId == id)
                .ToListAsync();
        }

        // GET: api/Pedidos/PorMotorista?id=2
        [HttpGet("PorMotorista")]
        public async Task<ActionResult<IEnumerable<Pedido>>> FiltrarPedidosPorMotorista(int id)
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Motorista)
                .Include(p => p.Plato)
                .Where(p => p.MotoristaId == id)
                .ToListAsync();
        }

        // POST, PUT y DELETE se generan automáticamente con el scaffolding.
    }
}
