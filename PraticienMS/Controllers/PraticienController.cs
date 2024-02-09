// PraticienController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraticienMS.Data;
using PraticienMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PraticienMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PraticienController : ControllerBase
    {
        private readonly PraticienDbContext _context;

        public PraticienController(PraticienDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Praticien>>> GetPraticiens()
        {
            return await _context.Praticiens.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Praticien>> GetPraticien(int id)
        {
            var praticien = await _context.Praticiens.FindAsync(id);

            if (praticien == null)
            {
                return NotFound();
            }

            return praticien;
        }

        [HttpPost]
        public async Task<ActionResult<Praticien>> PostPraticien(Praticien praticien)
        {
            _context.Praticiens.Add(praticien);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPraticien), new { id = praticien.Id }, praticien);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPraticien(int id, Praticien praticien)
        {
            if (id != praticien.Id)
            {
                return BadRequest();
            }

            _context.Entry(praticien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PraticienExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePraticien(int id)
        {
            var praticien = await _context.Praticiens.FindAsync(id);
            if (praticien == null)
            {
                return NotFound();
            }

            _context.Praticiens.Remove(praticien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PraticienExists(int id)
        {
            return _context.Praticiens.Any(e => e.Id == id);
        }
    }
}
