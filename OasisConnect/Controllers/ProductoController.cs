using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OasisConnect.Models;

namespace OasisConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly OasisContext _context;

        public ProductoController(OasisContext context)
        {
            _context = context;
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }
    }
}