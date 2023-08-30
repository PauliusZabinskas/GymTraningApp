using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTraningApp.Models.Identity
{
    public class RegisterRequestService
    {
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}