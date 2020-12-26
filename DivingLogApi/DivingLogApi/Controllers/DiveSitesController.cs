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
    public class DiveSitesController : ControllerBase
    {
        //private readonly DivingLogContext _context;
        private readonly DiveSiteService _diveSiteService;

        public DiveSitesController(DiveSiteService diveSiteService)
        {
            _diveSiteService = diveSiteService;
        }

        // GET: api/DiveSites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiveSite>>> GetDiveSites()
        {
            var allDiveSites = await Task.Run(() => _diveSiteService.GetAllDiveSites());

            return allDiveSites;
        }

        // POST: api/DiveSites
        [HttpPost]
        public async Task<ActionResult<DiveSite>> CreateDiveSite(DiveSite diveSite)
        {
            var createdDiveSite = await Task.Run(() => _diveSiteService.CreateDiveSite(diveSite));

            return createdDiveSite;
        }

    }
}
