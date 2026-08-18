using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OasisConnect.Models;

namespace OasisConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HamacaController : ControllerBase
    {
        private readonly OasisContext _context;

        public HamacaController(OasisContext context)
        {
            _context = context;
        }

        // GET: api/Hamacas/5
        // Este endpoint busca una hamaca específica por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Hamaca>> GetHamaca(int id)
        {
            var hamaca = await _context.Hamacas.FindAsync(id);

            if (hamaca == null)
            {
                return NotFound(); // Devuelve un error 404 si el QR escaneado no existe
            }

            return hamaca;
        }
    }
}