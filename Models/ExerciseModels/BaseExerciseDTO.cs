using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace GymApp.Models.Exercise.DTOs
{
    public abstract class BaseExerciseDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        public int? GymSessionID { get; set; } = null!;
    }
}