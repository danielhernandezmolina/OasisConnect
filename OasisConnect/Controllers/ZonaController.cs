using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OasisConnect.Models;

namespace OasisConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonaController : ControllerBase
    {
        private readonly OasisContext _context;

        public ZonaController(OasisContext context)
        {
            _context = context;
        }

        // GET: api/Zonas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zona>>> GetZonas()
        {
            return await _context.Zonas.ToListAsync();
        }
    }
}