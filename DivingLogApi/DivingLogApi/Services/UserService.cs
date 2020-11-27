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
    public class UserService
    {
        private readonly DivingLogContext _context;

        public UserService(DivingLogContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<User>>> getAllUsers()
        {
            return await _context.Users.Include(u => u.UserDives).ToListAsync();
        }

        //public List<User> getAllUsers()
        //{
        //    List<User> allUsers = _context.Users.ToList();

        //    return allUsers;
        //}
    }
}
