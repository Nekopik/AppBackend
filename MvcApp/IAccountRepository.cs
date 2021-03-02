using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MvcApp.Models;

namespace MvcApp
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
    }
}