using DivingLogApi.Dtos;
using DivingLogApi.Models;
using DivingLogApi.Services;
using DotNetOpenAuth.InfoCard;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationServices services;
        private readonly IConfiguration configuration;

        public AuthorizationController(IAuthorizationServices services, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.services = services;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForAuthorizationDto userDto)
        {
            userDto.Login = userDto.Login.ToLower();

            if (await services.UserExist(userDto.Login))
            {
                return BadRequest("Podany login jest już zajęty");
            }

            var userToCreate = new User
            {
                Login = userDto.Login,
                About = userDto.About,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
            };


            await services.Register(userToCreate, userDto.Password);

            return StatusCode(201);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> RemoveUser([FromBody] UserForAuthorizationDto userDto)
        {
            userDto.Login = userDto.Login.ToLower();

            if (!await services.UserExist(userDto.Login))
            {
                return BadRequest("Podany login nie istnieje");
            }
             
            if(await services.Delete(userDto.Login, userDto.Password))
            {
                return BadRequest("Usuwanie nie powiodło się. Sprawdź, czy podałeś poprawne hasło.");
            }

            

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
