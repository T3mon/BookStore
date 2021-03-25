using BLL;
using BLL.Service.Interfaces;
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
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly BookService _bookService;
        private readonly IEmailSender _emailSender;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, BookService bookService, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _bookService = bookService;
            _emailSender = emailSender;
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = "")
        {
            if (!TryValidateModel(model)) return StatusCode(500);

            var user = new User()
            {
                Email = model.Email,
                UserName = model.Login
            };
            var res = await _userManager.CreateAsync(user, model.Password);
            if (!res.Succeeded) return RedirectToAction("Register", "Accout");

            //User creation
            if (await _roleManager.FindByNameAsync("user") == null)
            {
                var role = await _roleManager.CreateAsync(new Role() { Name = "user" });
                if (role.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user");
                }
            }
            else await _userManager.AddToRoleAsync(user, "user");
            //Account confiramtion
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var link = Url.Action("Confirm", "Account",
                new { guid = token, userEmail = user.Email }, Request.Scheme, Request.Host.Value);
            await _emailSender.SendEmailAsync(user.Email, "Link ->>> ", link);

            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "")
        {
            if (!TryValidateModel(model)) return StatusCode(500);

            var user = new User()
            {
                Email = model.Email,
                UserName = model.Login
            };
            var res = await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.isRememberMe, false);
            if (res.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //RESET PASSWORD

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ResetPasswordAsync(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var link = Url.Action("ChangePassword", "Account",
                new { guid = token, userEmail = user.Email }, Request.Scheme, Request.Host.Value);
            await _emailSender.SendEmailAsync(user.Email, "Link ->>>", link);

            // add Send View 
            return Redirect("/home/index");

        }

        [HttpGet]
        public IActionResult ChangePasswordAsync(string userEmail, string guid)
        {
            return View(new ResetPasswordViewModel() { Email = userEmail, Guid = guid });
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ConfirmResetPasswordAsync(ResetPasswordViewModel model)
        {
            if (!TryValidateModel(model)) return View();

            var user = await _userManager.FindByEmailAsync(model.Email);
            var res = await _userManager.ResetPasswordAsync(user, model.Guid, model.Password);
            //todo add view changePassword Success
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmAsync(string guid, string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(email: userEmail);
            var res = await _userManager.ConfirmEmailAsync(user, guid);
            if (res.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            //todo add ERROR PAGE
            return View();
        }
    }
}
