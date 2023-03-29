using GiveMED.Api.Data;
using GiveMED.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Controllers
{
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
