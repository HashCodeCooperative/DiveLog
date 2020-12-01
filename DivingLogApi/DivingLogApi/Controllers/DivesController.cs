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
    public class DivesController : ControllerBase
    {
        //private readonly DivingLogContext _context;
        private readonly UserService _userService;
        private readonly DiveService _diveService;

        public DivesController(UserService userService, DiveService diveService)
        {
            _userService = userService;
            _diveService = diveService;
        }

        // GET: api/Dives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dive>>> GetDives()
        {
            var allDives = await Task.Run(() => _diveService.GetAllDives());

            return allDives;
        }

    }
}
