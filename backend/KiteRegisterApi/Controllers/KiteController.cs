using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KiteRegisterApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<KiteDto>>> GetKites()
        {
            return await _context.Kites.Select(kite => KiteToDto(kite)).ToListAsync();
        }

        // GET: api/Kite/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KiteDto>> GetKite(int id)
        {
            var kite = await _context.Kites.FindAsync(id);

            if (kite == null)
            {
                return NotFound();
            }

            return KiteToDto(kite);
        }

        // PUT: api/Kite/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKite(int id, KiteDto kiteDto)
        {
            if (id != kiteDto.KiteId) return BadRequest();

            var kite = await _context.Kites.FindAsync(id);
            if (kite == null) return NotFound();

            kite.UpdateDetails(kiteDto.Size, kiteDto.PrincipalColor, kiteDto.PurchaseDate);
            kite.UpdateKiteModel(kiteDto.KiteModelId);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!KiteExists(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Kite
        [HttpPost]
        public async Task<ActionResult<KiteDto>> PostKite(KiteDto kiteDto)
        {
            var kite = new Kite(kiteDto.Size, kiteDto.PrincipalColor, kiteDto.PurchaseDate, kiteDto.KiteModelId);

            _context.Kites.Add(kite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKite), new { id = kiteDto.KiteId }, KiteToDto(kite));
        }

        // DELETE: api/Kite/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKite(int id)
        {
            var kite = await _context.Kites.FindAsync(id);
            if (kite == null)
            {
                return NotFound();
            }

            _context.Kites.Remove(kite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KiteExists(int id)
        {
            return _context.Kites.Any(e => e.KiteId == id);
        }

        private static KiteDto KiteToDto(Kite kite)
        {
            return new KiteDto() { KiteId = kite.KiteId, KiteModelId = kite.KiteModelId, PrincipalColor = kite.PrincipalColor, PurchaseDate = kite.PurchaseDate, Size = kite.Size };
        }

    }
}
