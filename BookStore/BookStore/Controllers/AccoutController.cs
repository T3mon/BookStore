using BookStore.Models;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AccoutController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        public AccoutController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register() => View();
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = "")
        {
            if (!TryValidateModel(model)) return StatusCode(500);

            var user = new User()
            {
                Email = model.Login,
                UserName = model.Login
            };
            var res = await _userManager.CreateAsync(user, model.Password);
            if (res.Succeeded)
            {
                if (await _roleManager.FindByNameAsync("user") == null)
                {
                    var role = await _roleManager.CreateAsync(new Role() { Name = "user" });
                    if (role.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "user");
                    }
                }
                else await _userManager.AddToRoleAsync(user, "user");
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Register", "Accout");

        }
        [HttpGet]
        public ActionResult Login() => View();
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "")
        {
            if (!TryValidateModel(model)) return StatusCode(500);

            var user = new User()
            {
                Email = model.Login,
                UserName = model.Login
            };
            var res = await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.isRememberMe, false);
            if (res.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
