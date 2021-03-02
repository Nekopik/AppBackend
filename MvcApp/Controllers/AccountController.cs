using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MvcApp.Models;
using MvcApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
                                  SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return Ok(User); //have to change
        }

        [HttpPost]
        public async Task<IActionResult> Register(SignUpUserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.FirstName, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Ok(User); //have to change
        }

    }
}
