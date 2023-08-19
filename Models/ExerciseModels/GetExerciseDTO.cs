using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Models.Exercise.DTOs;
using GymApp.Models.ExerciseModels.DTOs;

namespace GymApp.Models.ExerciseModels.DTOs;

public class GetExerciseDTO : BaseExerciseDTO
{
    public int Id { get; set; }

    public int GymSessionID { get; set; }

}