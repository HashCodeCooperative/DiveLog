using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DivingLogApi.Data;
using DivingLogApi.Models;
using DivingLogApi.Services;

namespace DivingLogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiveSitesController : ControllerBase
    {
        //private readonly DivingLogContext _context;
        private readonly DiveSiteService _diveSiteService;

        public DiveSitesController(DiveSiteService diveSiteService)
        {
            _diveSiteService = diveSiteService;
        }

        // GET: api/DiveSites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiveSite>>> GetDiveSites()
        {
            var allDiveSites = await Task.Run(() => _diveSiteService.GetAllDiveSites());

            return allDiveSites;
        }

        // POST: api/DiveSites
        [HttpPost]
        public async Task<ActionResult<DiveSite>> CreateDiveSite(DiveSite diveSite)
        {
            var createdDiveSite = await Task.Run(() => _diveSiteService.CreateDiveSite(diveSite));

            return createdDiveSite;
        }

        //// GET: api/DiveSites/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<DiveSite>> GetDiveSite(int id)
        //{
        //    var diveSite = await _context.DiveSites.FindAsync(id);

        //    if (diveSite == null)
        //    {
        //        return NotFound();
        //    }

        //    return diveSite;
        //}

        //// PUT: api/DiveSites/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDiveSite(int id, DiveSite diveSite)
        //{
        //    if (id != diveSite.DiveSiteId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(diveSite).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DiveSiteExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}



        //// DELETE: api/DiveSites/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDiveSite(int id)
        //{
        //    var diveSite = await _context.DiveSites.FindAsync(id);
        //    if (diveSite == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DiveSites.Remove(diveSite);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool DiveSiteExists(int id)
        //{
        //    return _context.DiveSites.Any(e => e.DiveSiteId == id);
        //}
    }
}
