using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Interfaces
{
    interface IUserRepository
    {
        IEnumerable<User> Users();
        User GetUser(int UserId);
        bool InsertUser(User User);
        User DeleteUser(int UserId);
        bool UpdateUser(User User);

        User ValidateUser(string username, string password);
        bool ChangeUserPassword(int userId, string oldPassword, string newPassword);
        string CreateResetPasswordToken(string usermail, string path);
        bool ResetUserPassword(int userId, out string pass);
        User LoginUserWithoutHash(string email, string password);
    }
}
