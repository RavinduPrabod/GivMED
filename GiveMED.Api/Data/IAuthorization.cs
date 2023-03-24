using GiveMED.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Data
{
    public interface IAuthorization
    {
        Task<User> Register(User user, string password);

        Task<User> Login(string username, string password);

        Task<bool> UserExists(string username);

        Task<User> PasswordReset(string username, string oldpassword, string newpassword);

        Task<User> PasswordReset(string username, string password);
    }
}
