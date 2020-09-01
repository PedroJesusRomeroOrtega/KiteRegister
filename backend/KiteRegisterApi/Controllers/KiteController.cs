using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace KiteRegisterApi.Controllers
{
    [Route("api/kites")]
    [ApiController]
    public class KiteController : ControllerBase
    {
        private readonly KiteRegisterContext _context;

        public KiteController(KiteRegisterContext context)
        {
            _context = context;
        }

        // GET: api/Kite
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kite>>> GetKites()
        {
            return await _context.Kites.ToListAsync();
        }

        // GET: api/Kite/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kite>> GetKite(int id)
        {
            var kite = await _context.Kites.FindAsync(id);

            if (kite == null)
            {
                return NotFound();
            }

            return kite;
        }

        // PUT: api/Kite/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKite(int id, Kite kite)
        {
            if (id != kite.Id)
            {
                return BadRequest();
            }

            _context.Entry(kite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KiteExists(id))
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

        // POST: api/Kite
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Kite>> PostKite(Kite kite)
        {
            _context.Kites.Add(kite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKite), new { id = kite.Id }, kite);
        }

        // DELETE: api/Kite/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kite>> DeleteKite(int id)
        {
            var kite = await _context.Kites.FindAsync(id);
            if (kite == null)
            {
                return NotFound();
            }

            _context.Kites.Remove(kite);
            await _context.SaveChangesAsync();

            return kite;
        }

        private bool KiteExists(int id)
        {
            return _context.Kites.Any(e => e.Id == id);
        }
    }
}
