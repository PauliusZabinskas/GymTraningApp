using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Models.ExerciseModels.DTOs;

namespace GymApp.Models.GymSession
{
    public class GetDetailGymSessionDTO : BaseGymSessionDTO
    {
        public int Id { get; set; }
        public string? OwnerId { get; set; } = null!;
        
        
        public List<GetExerciseDTO>? Exercises { get; set; }

    }
}