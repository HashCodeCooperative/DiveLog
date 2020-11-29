using DivingLogApi.Data;
using DivingLogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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

        public async Task<ActionResult<IEnumerable<UserDive>>> GetAllUserDives(int id)
        {
            var userDives = _context.UserDives.Where(ud => ud.User.UserId == id).ToListAsync();

            return await userDives;
        }

        public async Task<ActionResult<JObject>> GetUserStatistics(int userId)
        {
            var user = await _context.Users.Include(u => u.UserDives).Where(u => u.UserId == userId).FirstAsync();
            var userName = user.FirstName;
            var userDives = user.UserDives;
            var numberOfDives = userDives.Count;
            var deepestDiveDepth = userDives.Max(ud => ud.MaxDepth);
            var longestDiveDuration = 80; // temporary implementantion

            string json = "{ 'userName': '"+
                userName +"', 'numberOfDives': '" +
                numberOfDives + "', 'deepestDiveDepth': '" +
                deepestDiveDepth + "', 'longestDiveDuration': '"+
                longestDiveDuration +"' }";

            JObject userDetails = JObject.Parse(json);

            //JObject userDetails = JObject.Parse(
            //    "{ 'userName': 'Lorenz', 'numberOfDives': '3', 'deepestDiveDepth': '70', 'longestDiveDuration': '83' }"
            //    );
            
            return userDetails;
        }

    }
}
