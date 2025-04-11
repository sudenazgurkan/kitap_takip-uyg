using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KitapTakip.Data;
using KitapTakip.Models;

namespace KitapTakip.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KitapController : ControllerBase
    {
        private readonly KitapTakipContext _context;

        public KitapController(KitapTakipContext context)
        {
            _context = context;
        }

        // GET: api/Kitap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kitap>>> GetKitaplar()
        {
            return await _context.Kitaplar.ToListAsync();
        }

        // GET: api/Kitap/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kitap>> GetKitap(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);

            if (kitap == null)
            {
                return NotFound();
            }

            return kitap;
        }

        // POST: api/Kitap
        [HttpPost]
        public async Task<ActionResult<Kitap>> PostKitap(Kitap kitap)
        {
            kitap.EklenmeTarihi = DateTime.Now;
            _context.Kitaplar.Add(kitap);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKitap), new { id = kitap.Id }, kitap);
        }

        // PUT: api/Kitap/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKitap(int id, Kitap kitap)
        {
            if (id != kitap.Id)
            {
                return BadRequest();
            }

            _context.Entry(kitap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KitapExists(id))
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

        // DELETE: api/Kitap/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKitap(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }

            _context.Kitaplar.Remove(kitap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KitapExists(int id)
        {
            return _context.Kitaplar.Any(e => e.Id == id);
        }
    }
} 