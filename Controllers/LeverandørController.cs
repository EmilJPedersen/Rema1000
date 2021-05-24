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
    public class LeverandørController : ControllerBase
    {
        private readonly RemaContext _context;

        public LeverandørController(RemaContext context)
        {
            _context = context;
        }

        // GET: api/Leverandør
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leverandør>>> GetLeverandør()
        {
            return await _context.Leverandør.ToListAsync();
        }

        // GET: api/Leverandør/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Leverandør>> GetLeverandør(int id)
        {
            var leverandør = await _context.Leverandør.FindAsync(id);

            if (leverandør == null)
            {
                return NotFound();
            }

            return leverandør;
        }

        // PUT: api/Leverandør/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeverandør(int id, Leverandør leverandør)
        {
            if (id != leverandør.Id)
            {
                return BadRequest();
            }

            _context.Entry(leverandør).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeverandørExists(id))
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

        // POST: api/Leverandør
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Leverandør>> PostLeverandør(Leverandør leverandør)
        {
            _context.Leverandør.Add(leverandør);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeverandør", new { id = leverandør.Id }, leverandør);
        }

        // DELETE: api/Leverandør/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeverandør(int id)
        {
            var leverandør = await _context.Leverandør.FindAsync(id);
            if (leverandør == null)
            {
                return NotFound();
            }

            _context.Leverandør.Remove(leverandør);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeverandørExists(int id)
        {
            return _context.Leverandør.Any(e => e.Id == id);
        }
    }
}
