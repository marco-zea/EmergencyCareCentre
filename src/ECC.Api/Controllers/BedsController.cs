using System.Collections.Generic;
using System.Threading.Tasks;
using ECC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECC.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BedsController : ControllerBase
    {
        private readonly ILogger<BedsController> _logger;
        private readonly EccDbContext _context;

        public BedsController(ILogger<BedsController> logger, EccDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]        
        public async Task<ActionResult<IEnumerable<Bed>>> Get()
        {
            var beds = await _context.Beds.ToListAsync();
            return new OkObjectResult(beds);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bed>> Get(int id)
        {
            var bed = await _context.Beds.FindAsync(id);

            if (bed == null)
            {
                return NotFound();
            }

            return new OkObjectResult(bed);
        }
    }
}
