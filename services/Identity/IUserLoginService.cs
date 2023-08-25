using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymTraningApp.Models.Identity;

namespace GymTraningApp.services.Identity
{
    public interface IUserLoginService
    {
        Task<bool> Login(string username, string password, bool rememberMe = true);
    }
}