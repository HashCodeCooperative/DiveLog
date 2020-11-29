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
    public class DiveService
    {
        private readonly DivingLogContext _context;

        public DiveService(DivingLogContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Dive>>> GetAllDives()
        {
            var allDives = _context.Dives
                //.Include(d => d.Divers)   //uncoment if you decide to eager load '<UserDive> aka Divers'
                .ToListAsync();

            return await allDives;
        }
    }
}
