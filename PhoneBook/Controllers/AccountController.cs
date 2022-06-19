using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = obj.Username;
                user.PasswordHash = obj.Password;
                user.Email = obj.Email;
                IdentityResult result = await userManager.CreateAsync(user,user.PasswordHash);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            //return View(obj);
            return RedirectToAction("MainPhoneBook", "PhoneBook");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogInSystem(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(login.Username);
                if(user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, login.Password, false,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("MainPhoneBook", "PhoneBook");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password not valid");
                }
            }
            //return View(login);
            return RedirectToAction("MainPhoneBook", "PhoneBook");
        }
    }
}
