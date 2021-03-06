using System.Collections.Generic;
using System.Threading.Tasks;
using ECC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ECC.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ILogger<CommentsController> _logger;
        private readonly EccDbContext _context;

        public CommentsController(ILogger<CommentsController> logger, EccDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> Get()
        {
            var comments = await _context.Comments
                .Include(c => c.Bed)
                .Include(c => c.Patient)
                .AsNoTracking()
                .ToListAsync();
            return new OkObjectResult(comments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> Get(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return new OkObjectResult(comment);
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> Post([FromBody]Comment comment)
        {
            var bed = await _context.Beds.FindAsync(comment.Bed.Id);
            if (bed == null)
            {
                _context.Beds.Add(comment.Bed);
                await _context.SaveChangesAsync();
            } else
            {
                bed.State = comment.Bed.State;
                comment.Bed = bed;
            }

            var patient = await _context.Patients.FindAsync(comment.Patient.Id);
            if (patient == null)
            {
                _context.Patients.Add(comment.Patient);
                await _context.SaveChangesAsync();
            } else
            {
                comment.Patient = patient;
            }                        

            _logger.LogInformation(JsonConvert.SerializeObject(comment));
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = comment.Id }, comment);
        }
    }
}
