using GiveMED.Api.Data;
using GiveMED.Api.Dto;
using GiveMED.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly DataContext _context;
        private readonly IAuthorization _repo;

        public UserController(DataContext context, IAuthorization repo)
        {
            _context = context;
            _repo = repo;
        }

        private bool UserExists(string UserName)
        {
            return _context.User.Any(e => e.UserName == UserName);
        }

        [HttpPost]
        [ActionName("PostUser")]
        public async Task<IActionResult> PostUser([FromBody] UserDto oUserForRegisterDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _repo.UserExists(oUserForRegisterDto.UserName.ToLower()))
                    ModelState.AddModelError("Username", "Username already exists");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var userToCreate = new User
                {
                    UserName = oUserForRegisterDto.UserName,
                    FirstName = oUserForRegisterDto.FirstName,
                    LastName = oUserForRegisterDto.LastName,
                    Type = oUserForRegisterDto.Type,
                    Status = oUserForRegisterDto.Status,
                    NoOfAttempts = oUserForRegisterDto.NoOfAttempts,
                    LastLoginDate = oUserForRegisterDto.LastLoginDate,
                    UserEmail = oUserForRegisterDto.Email,
                    CreatedBy = oUserForRegisterDto.CreatedBy,
                    CreatedDateTime = oUserForRegisterDto.CreatedDateTime,
                    CreatedWorkStation = oUserForRegisterDto.CreatedWorkStation,
                    ModifiedBy = oUserForRegisterDto.ModifiedBy,
                    ModifiedDateTime = oUserForRegisterDto.ModifiedDateTime,
                    ModifiedWorkStation = oUserForRegisterDto.ModifiedWorkStation
                };

                var createdUser = await _repo.Register(userToCreate, oUserForRegisterDto.Password);
                return Ok(CreatedAtAction("GetUser", new { username = createdUser.UserName }, createdUser));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // Return the appropriate error code and message
            }

        }


        [HttpGet]
        [ActionName("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return (from A in _context.User
                    select new User
                    {
                        UserName = A.UserName,
                        FirstName = A.FirstName,
                        LastName = A.LastName,
                        Type = A.Type,
                        Status = A.Status
                    }).ToList();
        }

        //[HttpGet("{username}")]
        //[ActionName("GetUser")]
        //public async Task<IActionResult> GetUser([FromRoute] string username)
        //{
        //    //var user = await _context.User.FirstOrDefault(x => x.UserName == username);
        //    //user.PasswordHash = null;
        //    //user.PasswordSalt = null;

        //    //if (user == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    return Ok(user);
        //}

        [HttpPost]
        [ActionName("PostDonor")]
        public async Task<IActionResult> PostDonor([FromBody] User oData)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //if (DocumentExists(oDocument.DocCode))
            //    ModelState.AddModelError("DocCode", "DocCode already exists");

            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            _context.User.Add(oData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        [ActionName("PutUser")]
        public async Task<IActionResult> PutUser([FromBody] User oUserForUpdateDto)
        {
            User currentUser = _context.User.Where(x => x.UserName == oUserForUpdateDto.UserName).FirstOrDefault();
            currentUser.FirstName = oUserForUpdateDto.FirstName;
            currentUser.LastName = oUserForUpdateDto.LastName;
            currentUser.Type = oUserForUpdateDto.Type;
            currentUser.Status = oUserForUpdateDto.Status;
            currentUser.UserEmail = oUserForUpdateDto.UserEmail;
            currentUser.ModifiedBy = oUserForUpdateDto.ModifiedBy;
            currentUser.ModifiedDateTime = oUserForUpdateDto.ModifiedDateTime;
            currentUser.ModifiedWorkStation = oUserForUpdateDto.ModifiedWorkStation;

            _context.Entry(currentUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(oUserForUpdateDto.UserName))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

    }
}
