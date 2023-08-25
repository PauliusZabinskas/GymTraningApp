using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Models.ExerciseModels.DTOs;

namespace GymApp.Models.GymSession
{
    public class UpdateGymSessionDTO :BaseGymSessionDTO
    {
    public int? Id { get; set; }

    public IEnumerable<GetExerciseDTO>? Exercises { get; set; } 
    }
}