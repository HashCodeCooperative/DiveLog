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
    public class UserDivesController : ControllerBase
    {
        private readonly DivingLogContext _context;

        public UserDivesController(DivingLogContext context)
        {
            _context = context;
        }

        // GET: api/UserDives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDive>>> GetUserDives()
        {
            return await _context.UserDives.Include(ud => ud.Dive).ToListAsync();
        }

        // GET: api/UserDives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDive>> GetUserDive(int id)
        {
            var userDive = await _context.UserDives.FindAsync(id);

            if (userDive == null)
            {
                return NotFound();
            }

            return userDive;
        }

        // PUT: api/UserDives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDive(int id, UserDive userDive)
        {
            if (id != userDive.UserDiveId)
            {
                return BadRequest();
            }

            _context.Entry(userDive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDiveExists(id))
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

        // POST: api/UserDives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDive>> PostUserDive(UserDive userDive)
        {
            _context.UserDives.Add(userDive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDive", new { id = userDive.UserDiveId }, userDive);
        }

        // DELETE: api/UserDives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDive(int id)
        {
            var userDive = await _context.UserDives.FindAsync(id);
            if (userDive == null)
            {
                return NotFound();
            }

            _context.UserDives.Remove(userDive);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDiveExists(int id)
        {
            return _context.UserDives.Any(e => e.UserDiveId == id);
        }
    }
}
