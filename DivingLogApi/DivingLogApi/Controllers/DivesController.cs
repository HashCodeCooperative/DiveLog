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
            return await _diveService.GetAllDives();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Dive>> DiveEdit(int id, Dive dive)
        {
            _diveService.DiveEdit(dive, id);
            return Ok(dive);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Dive>> DeleteDive(int id)
        {
            var isDelete = await _diveService.DeleteDive(id);

            if (isDelete)
                return Ok();
            else
                return BadRequest();
        } 
    }
}
