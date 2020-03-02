using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArch.Mvc.Controllers
{
    //[Authorize]
    public class UsersController : Controller
    {
        private IUserService _userService;
        public UsersController(IUserService userService)          
        {
            _userService = userService;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult GetUsers()
        {
            UserViewModel model = _userService.GetUsers();
            return View(model);
        }
    }
}
