using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RdvMS.Data;
using RdvMS.Models.Rdv;


namespace RdvMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RdvController : ControllerBase
    {
        private readonly RdvDbContext _context;

        public RdvController(RdvDbContext context)
        {
            _context = context;
        }

        // GET: api/Rdv
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rdv>>> GetRdvs()
        {
            return await _context.Rdvs.ToListAsync();
        }

        // GET: api/Rdv/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rdv>> GetRdv(int id)
        {
            var rdv = await _context.Rdvs.FindAsync(id);

            if (rdv == null)
            {
                return NotFound();
            }

            return rdv;
        }

        // POST: api/Rdv
        [HttpPost]
        public async Task<ActionResult<Rdv>> PostRdv(Rdv rdv)
        {
            _context.Rdvs.Add(rdv);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRdv), new { id = rdv.Id }, rdv);
        }

        // PUT: api/Rdv/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRdv(int id, Rdv rdv)
        {
            if (id != rdv.Id)
            {
                return BadRequest();
            }

            _context.Entry(rdv).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RdvExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Rdv/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRdv(int id)
        {
            var rdv = await _context.Rdvs.FindAsync(id);
            if (rdv == null)
            {
                return NotFound();
            }

            _context.Rdvs.Remove(rdv);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RdvExists(int id)
        {
            return _context.Rdvs.Any(e => e.Id == id);
        }
    }
}
