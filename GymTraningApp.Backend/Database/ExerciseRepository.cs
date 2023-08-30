using GymApp.Models;
using GymApp.Models.ExerciseModels;
using GymApp.services;
using GymApp.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GymApp.Database;

/// <summary>
/// This is the Exercise Repository. You have two tasks here:
/// 1. Error Handling.
/// 2. Enable paging for ListExercises Method
/// 
/// If you're up for the challenge, figure out how to make a generic
/// repository
/// </summary>
public class ExerciseRepository : IExerciseRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ICurrentSession _currentSession;

    public ExerciseRepository(ApplicationDbContext dbContext, ICurrentSession currentSession)
    {
        _currentSession = currentSession;
        _dbContext = dbContext;
    }

    public async Task<Exercise> AddExercise(Exercise exercise)
    {
        
        EntityEntry<Exercise> created = await _dbContext.AddAsync(exercise);
        await _dbContext.SaveChangesAsync();
        return created.Entity;
    }

    public async Task DeleteExercise(int exerciseId)
    {
        Exercise? exercise = await GetExercise(exerciseId);

        _dbContext.Remove(exercise);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Exercise?> GetExercise(int exerciseId)
    {

        return await _dbContext.Exercises.FindAsync(exerciseId);
        

    }

    public async Task<IEnumerable<Exercise>> ListExercises()
    {


        return await Task.FromResult(
            _dbContext.Exercises.ToList()
            .Where(ex => ex.GymSessionID == _currentSession.SessionId)
        );
    }

    public async Task UpdateExercise(Exercise exercise)
    {
        
        _dbContext.Exercises.Update(exercise);
        await _dbContext.SaveChangesAsync();
    }

    
}
