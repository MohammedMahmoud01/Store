using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Models;
using Microsoft.AspNetCore.Identity;

namespace Store.Controllers
{
    public class UsersController : Controller
    {
        UserManager<ApplicationUser> userManager;

        SignInManager<ApplicationUser> SignInManager;
        public UsersController(UserManager<ApplicationUser> manager,
            SignInManager<ApplicationUser> manager1)
        {
            userManager = manager;
            SignInManager = manager1;
        }
        public IActionResult Login(string ReturnUrl)
        {
            return View(new UserModel()
            {
                ReturnUrl = ReturnUrl
            });
        }
        public IActionResult Register()
        {
            return View(new UserModel());
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAction(UserModel userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.Email
            };
            if (userModel.Password == null)
                userModel.Password = "2";

            var result = await userManager.CreateAsync(user, userModel.Password);

            if (result.Succeeded)
                return Redirect("~/");
            else
                return View("Register", userModel);

        }

        [HttpPost]
        public async Task<IActionResult> LoginAction(UserModel userModel)
        {
            var result = await SignInManager.PasswordSignInAsync(userModel.Email , 
                userModel.Password , true , true);

            if (string.IsNullOrEmpty(userModel.ReturnUrl))
                userModel.ReturnUrl = "~/";

            if (result.Succeeded)
                return Redirect(userModel.ReturnUrl);
            else
                return View("Register", userModel);

        }
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return Redirect("~/");
        }
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
