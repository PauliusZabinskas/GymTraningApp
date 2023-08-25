using GymTraningApp.services.Identity;
using Microsoft.AspNetCore.Identity;

namespace GymApp.Identity;

public class UserRegisterService : IUserRegisterService
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserRegisterService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> Register(string userName, string password, string email)
    {
        IdentityUser user = new IdentityUser
        {
            UserName = userName,
            Email = email
        };

        IdentityResult result = await _userManager.CreateAsync(user, password);

        return result.Succeeded;
    }
}