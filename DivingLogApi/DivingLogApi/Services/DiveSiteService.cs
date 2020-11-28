using DivingLogApi.Data;
using DivingLogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivingLogApi.Services
{
    public class DiveSiteService
    {
        private readonly DivingLogContext _context;

        public DiveSiteService(DivingLogContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<DiveSite>>> GetAllDiveSites()
        {
            var allDiveSites = _context.DiveSites.ToListAsync();

            return await allDiveSites;
        }

        public async Task<ActionResult<DiveSite>> CreateDiveSite(DiveSite diveSite)
        {
            _context.DiveSites.Add(diveSite);
            await _context.SaveChangesAsync();

            return diveSite;
        }

    }
}
