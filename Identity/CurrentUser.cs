using GymApp.Services;

namespace GymApp.Identity;

public class CurrentUser : ICurrentUser
{
    public string? UserId => "testId";
}