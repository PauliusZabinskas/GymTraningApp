using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Models.GymSession
{
    public abstract class BaseGymSessionDTO
    {
        
        public string? Title { get; set; } = null!;
    }
}