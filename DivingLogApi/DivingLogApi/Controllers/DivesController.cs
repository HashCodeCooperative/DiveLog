using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DivingLogApi.Data;
using DivingLogApi.Models;

namespace DivingLogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivesController : ControllerBase
    {
        private readonly DivingLogContext _context;

        public DivesController(DivingLogContext context)
        {
            _context = context;
        }

        // GET: api/Dives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dive>>> GetDives()
        {
            return await _context.Dives.ToListAsync();
        }

        // GET: api/Dives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dive>> GetDive(int id)
        {
            var dive = await _context.Dives.FindAsync(id);

            if (dive == null)
            {
                return NotFound();
            }

            return dive;
        }

        // PUT: api/Dives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDive(int id, Dive dive)
        {
            if (id != dive.DiveId)
            {
                return BadRequest();
            }

            _context.Entry(dive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiveExists(id))
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

        // POST: api/Dives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dive>> PostDive(Dive dive)
        {
            _context.Dives.Add(dive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDive", new { id = dive.DiveId }, dive);
        }

        // DELETE: api/Dives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDive(int id)
        {
            var dive = await _context.Dives.FindAsync(id);
            if (dive == null)
            {
                return NotFound();
            }

            _context.Dives.Remove(dive);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiveExists(int id)
        {
            return _context.Dives.Any(e => e.DiveId == id);
        }
    }
}
