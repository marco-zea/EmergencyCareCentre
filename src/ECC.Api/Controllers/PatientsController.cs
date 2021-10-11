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
    public class PatientsController : ControllerBase
    {
        private readonly ILogger<PatientsController> _logger;
        private readonly EccDbContext _context;

        public PatientsController(ILogger<PatientsController> logger, EccDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> Get()
        {
            var patients = await _context.Patients.ToListAsync();
            return new OkObjectResult(patients);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Get(string id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return new OkObjectResult(patient);
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> Post(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = patient.Id }, patient);
        }
    }
}
