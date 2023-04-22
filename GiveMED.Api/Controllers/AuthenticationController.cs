using GiveMED.Api.Data;
using GiveMED.Api.Dto;
using GiveMED.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                                 join B in _context.HospitalMaster on A.UserName equals B.UserName
                                 where A.UserName == userForLoginDto.UserName && A.Type == 3
                                 select new LoggedUserDto
                                 {
                                     UserName = A.UserName,
                                     FirstName = A.FirstName,
                                     LastName = A.LastName,
                                     Type = A.Type,
                                     Status = A.Status,
                                     HospitalID = B.HospitalID,
                                     TokenString = tokenString.ToString()
                                 }).First();

            return Ok(loggedUserDto);
        }

        [HttpPost]
        [ActionName("PasswordReset")]
        public async Task<User> PasswordReset([FromBody] ChangePwdDto oChangePwdDto)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserName == oChangePwdDto.UserName);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(oChangePwdDto.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(oChangePwdDto.NewPassword, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Status = 1;
            user.NoOfAttempts = 0;

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

        [HttpGet("{UserName}")]
        [ActionName("GetIsDonorAvailability")]
        public bool GetIsDonorAvailability(string UserName)
        {
            bool isAvailable = false;
            isAvailable = _context.DonorMaster.Where(x => x.UserName == UserName).Any();

            return isAvailable;
        }

        [HttpGet("{UserName}")]
        [ActionName("GetIsHospitalAvailability")]
        public bool GetIsHospitalAvailability(string UserName)
        {
            bool isAvailable = false;
            isAvailable = _context.HospitalMaster.Where(x => x.UserName == UserName).Any();

            return isAvailable;
        }
    }
}
