using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rema1000.Models;

namespace Rema1000.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktsController : ControllerBase
    {
        private readonly RemaContext _context;

        public ProduktsController(RemaContext context)
        {
            _context = context;
        }

        // GET: api/Produkts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produkt>>> GetProdukt()
        {
            return await _context.Produkt.ToListAsync();
        }

        // GET: api/Produkts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produkt>> GetProdukt(int id)
        {
            var produkt = await _context.Produkt.FindAsync(id);

            if (produkt == null)
            {
                return NotFound();
            }

            return produkt;
        }

        // PUT: api/Produkts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdukt(int id, Produkt produkt)
        {
            if (id != produkt.ProduktId)
            {
                return BadRequest();
            }

            _context.Entry(produkt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduktExists(id))
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

        // POST: api/Produkts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produkt>> PostProdukt(Produkt produkt)
        {
            _context.Produkt.Add(produkt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdukt", new { id = produkt.ProduktId }, produkt);
        }

        // DELETE: api/Produkts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdukt(int id)
        {
            var produkt = await _context.Produkt.FindAsync(id);
            if (produkt == null)
            {
                return NotFound();
            }

            _context.Produkt.Remove(produkt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProduktExists(int id)
        {
            return _context.Produkt.Any(e => e.ProduktId == id);
        }
    }
}
