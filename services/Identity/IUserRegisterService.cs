using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTraningApp.services.Identity
{
    public interface IUserRegisterService
    {
        Task<bool>  Register(string userName, string password, string email);
    }
}