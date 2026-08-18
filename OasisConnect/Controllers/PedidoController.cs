using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OasisConnect.Models;

namespace OasisConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly OasisContext _context;

        public PedidoController(OasisContext context)
        {
            _context = context;
        }

        // GET: api/Pedidos/5
        // Sirve para que el cliente o el camarero pueda revisar el estado de un pedido específico
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            // Include() hace un "JOIN" para traernos también los detalles del pedido (los productos elegidos)
            var pedido = await _context.Pedidos
                .Include(p => p.DetallePedidos)
                .FirstOrDefaultAsync(p => p.IdPedidos == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // POST: api/Pedidos
        // Este endpoint RECIBE el nuevo pedido desde el móvil y lo guarda en MySQL
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos

            // Devuelve un código 201 (Creado) y la URL para consultar el pedido que se acaba de crear
            return CreatedAtAction(nameof(GetPedido), new { id = pedido.IdPedidos }, pedido);
        }
    }
}