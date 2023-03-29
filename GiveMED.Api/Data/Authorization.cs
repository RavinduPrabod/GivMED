using GiveMED.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Data
{
    public class Authorization : IAuthorization
    {
        private readonly DataContext _context;

        public Authorization(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public Task<User> PasswordReset(string username, string oldpassword, string newpassword)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> PasswordReset(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.User.AnyAsync(x => x.UserName == username))
                return true;

            return false;
        }

        //public async Task<User> PasswordReset(string username, string oldpassword, string newpassword)
        //{
        //    var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);

        //    if (user == null)
        //        return null;

        //    if (!VerifyPasswordHash(oldpassword, user.PasswordHash, user.PasswordSalt))
        //        return null;

        //    byte[] passwordHash, passwordSalt;
        //    CreatePasswordHash(newpassword, out passwordHash, out passwordSalt);

        //    user.PasswordHash = passwordHash;
        //    user.PasswordSalt = passwordSalt;
        //    user.Status = (int)UserStatus.Active;
        //    user.NoOfAttempts = 0;

        //    _context.Entry(user).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();

        //    return user;
        //}

        //public async Task<User> PasswordReset(string username, string password)
        //{
        //    var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);

        //    if (user == null)
        //        return null;

        //    byte[] passwordHash, passwordSalt;
        //    CreatePasswordHash(password, out passwordHash, out passwordSalt);

        //    user.PasswordHash = passwordHash;
        //    user.PasswordSalt = passwordSalt;
        //    user.Status = (int)UserStatus.Active;

        //    _context.Entry(user).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();

        //    return user;
        //}

        #region Private Methods

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

        #endregion Private Methods
    }
}
