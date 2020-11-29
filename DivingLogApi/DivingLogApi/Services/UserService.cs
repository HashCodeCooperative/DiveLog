﻿using DivingLogApi.Data;
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

        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var allUsers = _context.Users.Include(u => u.UserDives).ToListAsync();

            return await allUsers;
        }

        internal async Task<ActionResult<IEnumerable<UserDive>>> GetAllUserDives(int id)
        {
            var userDives = _context.UserDives.Where(ud => ud.User.UserId == id).ToListAsync();

            return await userDives;
        }

    }
}
