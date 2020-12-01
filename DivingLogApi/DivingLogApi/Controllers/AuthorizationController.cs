using DivingLogApi.Dtos;
using DivingLogApi.Models;
using DivingLogApi.Services;
using DotNetOpenAuth.InfoCard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DivingLogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationServices services;
        private readonly IConfiguration configuration;

        public AuthorizationController(IAuthorizationServices services, IConfiguration configuration )
        {
            this.configuration = configuration;
            this.services = services;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForAuthorizationDto userDto)
        {
            userDto.Login = userDto.Login.ToLower();

            if(await services.UserExist(userDto.Login))
            {
                return BadRequest("Podany login jest już zajęty");
            }

            var userToCreate = new User
            {
                Login = userDto.Login,
            };

             
            await services.Register(userToCreate, userDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto loginDto)
        {
            var userFromBase = await services.Login(loginDto.Login, loginDto.Password);

            if (userFromBase is null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromBase.UserId.ToString()),
                new Claim(ClaimTypes.Name, userFromBase.Login.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = creds,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token) });
        } 
    }
}
