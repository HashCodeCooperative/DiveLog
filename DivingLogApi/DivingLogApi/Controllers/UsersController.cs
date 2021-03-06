﻿using System;
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
using Microsoft.AspNetCore.Cors;

namespace DivingLogApi.Controllers
{
    [EnableCors]
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
            return await _userService.GetAllUsers();
        }

        // GET: api/Users/5/Dives
        [HttpGet("{id}/Dives")]
        public async Task<ActionResult<IEnumerable<UserDive>>> GetAllUserDives(int id)
        { 
            return await _userService.GetAllUserDives(id);
        }

        // GET: api/Users/5/statistics
        
        [HttpGet("{id}/statistics")]
        public async Task<ActionResult<JObject>> GetUsersStatistics(int id)
        { 
            return await _userService.GetUserStatistics(id);
        }
         
        // POST: api/Users/5/UserDives/DiveSites/3
        [HttpPost("{userId}/UserDives/DiveSites/{diveSiteId}")]
        public async Task<ActionResult<UserDive>> RegisterNewDive(UserDive userDive, int userId, int diveSiteId)
        { 
            return await _userDiveService.RegisterNewDive(userDive, userId, diveSiteId);
        }

    }
}
