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
    public class SignInController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public SignInController(UserManager<IdentityUser> userManager,
                                  SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpPut]
        public async Task<IActionResult> Register(SignUpUserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }
                return BadRequest();
            }
            return BadRequest(); 
        }

    }
}
