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
    public class UserDiveService
    {
        private readonly DivingLogContext _context;

        public UserDiveService(DivingLogContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<UserDive>> GetUserDiveDetails(int id)
        {
            var userDiveDetails = _context.UserDives
                .Include(ud => ud.Dive)
                    .ThenInclude(d => d.DiveSite)
                .Include(ud => ud.Dive)
                    .ThenInclude(d => d.Divers)
                .FirstAsync(ud => ud.UserDiveId == id);

            return await userDiveDetails;
        }

    }
}
