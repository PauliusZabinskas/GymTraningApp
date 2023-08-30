
using GymTraningApp.services.Identity;
using Microsoft.AspNetCore.Identity;

namespace GymTraningApp.Identity
{
    public class LoginService : IUserLoginService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> Login(string username, string password, bool rememberMe)
        {
            IdentityUser? existingUser = await _userManager.FindByNameAsync(username);

            if (existingUser == null)
                return false;
            
            SignInResult result = await _signInManager.PasswordSignInAsync(username,password, rememberMe, false);
            return result.Succeeded;
        }


    }
}