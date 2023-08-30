using GymApp.Models;
using GymApp.Models.ExerciseModels;

namespace GymApp.Services;

public interface IExerciseRepository
{
    Task<Exercise?> GetExercise(int exerciseId);
    Task<IEnumerable<Exercise>> ListExercises();
    Task<Exercise> AddExercise(Exercise exercise);
    Task UpdateExercise(Exercise exercise);
    Task DeleteExercise(int exerciseId);
    
}