using DivingLogApi.Dtos;
using DivingLogApi.Models;
using DivingLogApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivingLogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationServices services;

        public AuthorizationController(IAuthorizationServices services )
        {
            this.services = services;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForAuthorizationDto userDto)
        {
            userDto.Login = userDto.Login.ToLower();

            if(await services.UserExist(userDto.Login))
            {
                return BadRequest("Podany login jest już zajęty");
            }

            var userToCreate = new User();
             
            var createdUser = await services.Register(userToCreate, userDto.Password);

            return StatusCode(201);
        }
    }
}
