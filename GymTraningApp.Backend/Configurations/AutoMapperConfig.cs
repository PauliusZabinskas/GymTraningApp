using AutoMapper;
using GymApp.Models;
using GymApp.Models.ExerciseModels;
using GymApp.Models.ExerciseModels.DTOs;
using GymApp.Models.GymSession;

namespace GymApp.Configurations;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Exercise, GetExerciseDTO>().ReverseMap();
        CreateMap<Exercise, CreateExerciseDTO>().ReverseMap();

        CreateMap<GymSession, GetGymSessionDTO>().ReverseMap();
        CreateMap<GymSession, CreateGymSessionDTO>().ReverseMap();
        CreateMap<GymSession, GetDetailGymSessionDTO>().ReverseMap();
        CreateMap<GymSession, UpdateGymSessionDTO>().ReverseMap();
    }
    
}