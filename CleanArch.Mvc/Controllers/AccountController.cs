using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CleanArch.Mvc.Repositories.Abstract;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using CleanArch.Mvc.ViewModels;
using CleanArch.Mvc.Helpers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArch.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IStringLocalizer<AccountController> _localizer;
        private readonly IHostingEnvironment _env;
        public AccountController(IUserRepository userRepository, IRoleRepository roleRepository, IStringLocalizer<AccountController> localizer, IHostingEnvironment env)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _localizer = localizer;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _userRepository.ValidateUser(email, password);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View();
            }
            if (user.Username == null)
            {
                user.Username = user.Firstname + user.Surname;

            }
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRole.Type));

            // For system with multiple roles per user 

            //foreach (var role in user.Roles)
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, role.Role));
            //}

            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {

            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            ResetPassword(model.Email, "test");
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            //if (model.AgreeWithTerms == true)
            //{

            //}  
            model.User.FullName = model.User.Firstname + model.User.Surname;
            model.User.IndustryId = 1;
            model.User.RoleId = 1;
            _userRepository.InsertUser(model.User);
            return RedirectToAction("Login", "Account");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }
        public void ResetPassword(string to, string body)
        {

            try
            {

                var result = _userRepository.CreateResetPasswordToken(to, "http://localhost:61849/");

                // var result = new UserDa().ResetUserPassword(txtEmail.Text, out pass);
                if (result != "")
                {

                    ModelState.AddModelError("", "Password is changed");


                    bool b = SendMailHelper.Send(to, result);

                    //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
                }
                else
                {
                    ModelState.AddModelError("", "Password is not changed");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

        }
        public IActionResult AddNewPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewPassword(AddNewPasswordViewModel model)
        {

            return View();
        }
    }
}
