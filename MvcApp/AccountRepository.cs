using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MvcApp.Models;

namespace MvcApp
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new IdentityUser()
            {
                Email = userModel.Email,
                UserName = userModel.FirstName
                
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }
    }
}
