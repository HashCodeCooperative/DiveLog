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
using Newtonsoft.Json.Linq;

namespace DivingLogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly UserDiveService _userDiveService;

        public UsersController(UserService userService, UserDiveService userDiveService)
        {
            _userService = userService;
            _userDiveService = userDiveService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var allUsers = await Task.Run(() => _userService.GetAllUsers());
            
            return allUsers;
        }

        // GET: api/Users/5/Dives
        [HttpGet("{id}/Dives")]
        public async Task<ActionResult<IEnumerable<UserDive>>> GetAllUserDives(int id)
        {
            var allUserDives = await Task.Run(() => _userService.GetAllUserDives(id));
            
            return allUserDives;
        }

        // GET: api/Users/5/statistics
        [HttpGet("{id}/statistics")]
        public async Task<ActionResult<JObject>> GetUsersStatistics(int id)
        {
            var userStats = await Task.Run(() => _userService.GetUserStatistics(id));

            return userStats;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser(User user)
        {
            var registeredUser = await Task.Run(() => _userService.RegisterUser(user));

            return registeredUser;
        }

        // POST: api/Users/5/UserDives/DiveSites/3
        [HttpPost("{userId}/UserDives/DiveSites/{diveSiteId}")]
        public async Task<ActionResult<UserDive>> RegisterNewDive(UserDive userDive, int userId, int diveSiteId)
        {
            var registeredDive = await Task.Run(() => _userDiveService.RegisterNewDive(userDive, userId, diveSiteId));

            return registeredDive;
        }

    }
}
