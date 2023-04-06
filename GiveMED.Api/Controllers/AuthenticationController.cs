using GiveMED.Api.Data;
using GiveMED.Api.Dto;
using GiveMED.Api.Models;
using Microsoft.AspNetCore.Http;
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

namespace GiveMED.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IAuthorization _repo;
        private readonly IConfiguration _config;

        public AuthenticationController(DataContext context, IAuthorization repo, IConfiguration config)
        {
            _context = context;
            _repo = repo;
            _config = config;
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            User userFromDb = await _repo.Login(userForLoginDto.UserName, userForLoginDto.Password);

            if (userFromDb == null)
                return Unauthorized();

            //generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userFromDb.UserName)
                }),
                Issuer = "",
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var loggedUserDto = (from A in _context.User
                                 where A.UserName == userForLoginDto.UserName
                                 select new LoggedUserDto
                                 {
                                     UserName = A.UserName,
                                     FirstName = A.FirstName,
                                     LastName = A.LastName,
                                     Type = A.Type,
                                     Status = A.Status,
                                     TokenString = tokenString.ToString()
                                 }).First();

            return Ok(loggedUserDto);
        }

        [HttpPost]
        [ActionName("HLogin")]
        public async Task<IActionResult> HLogin([FromBody] UserForLoginDto userForLoginDto)
        {
            User userFromDb = await _repo.Login(userForLoginDto.UserName, userForLoginDto.Password);

            if (userFromDb == null)
                return Unauthorized();

            //generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userFromDb.UserName)
                }),
                Issuer = "",
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var loggedUserDto = (from A in _context.User
                                 where A.UserName == userForLoginDto.UserName && A.Type == 3
                                 select new LoggedUserDto
                                 {
                                     UserName = A.UserName,
                                     FirstName = A.FirstName,
                                     LastName = A.LastName,
                                     Type = A.Type,
                                     Status = A.Status,
                                     TokenString = tokenString.ToString()
                                 }).First();

            return Ok(loggedUserDto);
        }

        [HttpPost]
        [ActionName("PasswordReset")]
        public async Task<IActionResult> PasswordReset([FromBody] ChangePwdDto oChangePwdDto)
        {
            User oUser = await _repo.PasswordReset(oChangePwdDto.UserName, oChangePwdDto.Password, oChangePwdDto.NewPassword);

            if (oUser == null)
                return Unauthorized();

            return Ok(oUser);
        }
    }
}
