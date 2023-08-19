using AutoMapper;
using GymApp.Models;
using GymApp.Models.ExerciseModels;
using GymApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GymApp.Database;
/// <summary>
/// This is the GymSession Repository. You have two tasks here:
/// 1. Error Handling.
/// 2. Enable paging for ListSessions Method
/// 
/// If you're up for the challenge, figure out how to make a generic
/// repository
/// </summary>
public class GymSessionRepository : IGymSessionRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ICurrentUser _currentUser;
    

    public GymSessionRepository(ApplicationDbContext dbContext, ICurrentUser currentUser)
    {
        _dbContext = dbContext;
        _currentUser = currentUser;
        
    }

    public async Task<GymSession> AddSession(GymSession session)
    {
        session.OwnerId = _currentUser.UserId;
        // Add the new gym session
        EntityEntry<GymSession> created = await _dbContext.GymSessions.AddAsync(session);
        // save changes
        await _dbContext.SaveChangesAsync();
        // return the added entity
        return created.Entity;
    }

    public async Task DeleteSession(int sessionId)
    {
        // Find the session
        GymSession? session = await _dbContext.GymSessions.FindAsync(sessionId);
        // remove the session
        _dbContext.GymSessions.Remove(session);
        // save changes
        await _dbContext.SaveChangesAsync();
    }

    public async Task<GymSession?> GetSession(int sessionId)
    {
        
        return await _dbContext.GymSessions
        .Include(session => session.Exercises)
        .FirstOrDefaultAsync(x => x.Id == sessionId);

    }

    public async Task<IEnumerable<GymSession>> ListSessions()
    {   // return all the sessions for the current user
        // Task.FromResult is syntax used to await something that isn't awaitable.
        // In this case, the Where method is not an async method, but we need to
        // return a Task. Hence, Task.FromResult
        return await Task.FromResult(
            _dbContext.GymSessions
            .Include(session => session.Exercises)
            .Where(x => x.OwnerId == _currentUser.UserId)
        );
    }

    public async Task UpdateSession(GymSession session)
    {
        
        _dbContext.GymSessions.Update(session);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task AppendExercise(GymSession session)
    {
        _dbContext.GymSessions.AddAsync(session);
        await _dbContext.SaveChangesAsync();
    }
}
