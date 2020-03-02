using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using Microsoft.Extensions.Configuration;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace CleanArch.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Db _context;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public UserRepository()
        {
            _context = new Db();
        }
        public bool ChangeUserPassword(int userId, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public string CreateResetPasswordToken(string usermail, string path)
        {
            throw new NotImplementedException();
        }

        public User DeleteUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public bool InsertUser(User User)
        {
            throw new NotImplementedException();
        }

        public User LoginUserWithoutHash(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool ResetUserPassword(int userId, out string pass)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User User)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Users()
        {
            DataTable dt;

            try
            {
                var cmd = _context.CreateCommand();
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                cmd.CommandText = "SELECT *, s.type, i.type FROM public.users a INNER JOIN public.roles s ON s.\"ID\" = a.\"FK_Role\" INNER JOIN public.industry i ON i.\"ID\"= a.\"FK_Industry\" ORDER bY a.\"ID\" DESC";

                dt = _context.ExecuteSelectCommand(cmd);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw new Exception(ex.Message);
            }

            List<User> list = (from DataRow dr in dt.Rows select CreateUserObject(dr)).ToList();

            return list;
        }

        public User ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        private static User CreateUserObject(DataRow dr)
        {
            var user = new User
            {
                Id = int.Parse(dr["ID"].ToString()),
                FullName = dr["fullname"].ToString(),
                Username = dr["username"].ToString(),
                Firstname = dr["firstname"].ToString(),
                Surname = dr["surname"].ToString(),
                Address = dr["address"].ToString(),
                City = dr["city"].ToString(),
                Phone = dr["phone"].ToString(),
                Email = dr["email"].ToString(),
                Active = bool.Parse(dr["active"].ToString()),
                Appruved = bool.Parse(dr["appruved"].ToString()),
                CompanyUser = bool.Parse(dr["company_user"].ToString()),
                UserIndustry = new Industry
                {
                    Id = int.Parse(dr["ID"].ToString()),
                    Type = dr["type"].ToString()
                },
                UserRole = new Role
                {
                    Id = int.Parse(dr["ID"].ToString()),
                    Type = dr["type"].ToString()
                }
            };
            return user;
        }
    }
}
