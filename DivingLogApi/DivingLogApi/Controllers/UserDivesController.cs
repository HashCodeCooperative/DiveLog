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
using Microsoft.AspNetCore.Cors;

namespace DivingLogApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class UserDivesController : ControllerBase
    {
        private readonly UserDiveService _userDiveService;

        public UserDivesController(UserDiveService userDiveService)
        {
            _userDiveService = userDiveService;
        }

        // GET: api/UserDives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDive>> GetUserDiveDetails(int id)
        {
            var userDiveDetails = await Task.Run(() => _userDiveService.GetUserDiveDetails(id)); 
            return userDiveDetails;
        } 
    }
}
