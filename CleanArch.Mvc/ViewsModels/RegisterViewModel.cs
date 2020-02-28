using CleanArch.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Mvc.ViewModels
{
    public class RegisterViewModel
    {
        //public string Email { get; set; }
        //public string City { get; set; }
        //public string FullName { get; set; }
        //public string Username { get; set; }
        //public string Firstname { get; set; }
        //public string Surname { get; set; }
        //public string Address { get; set; }
        //public string Password { get; set; }
        //public string Phone { get; set; }
        //public bool Active { get; set; }
        //public bool Appruved { get; set; }
        //public bool CompanyUser { get; set; }
        //public int RoleId { get; set; }
        //public int IndustryId { get; set; }
        //public int CompanyId { get; set; }
        //public int CountryId { get; set; }
        public User User { get; set; }
        public bool AgreeWithTerms { get; set; }
    }
}
