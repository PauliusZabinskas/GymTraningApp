using GymApp.Models;
using GymApp.Models.ExerciseModels;

namespace GymApp.Services;

public interface IGymSessionRepository
{
    /// <summary>
    /// Retrieves a session by Id
    /// </summary>
    /// <param name="sessionId">The session Id</param>
    /// <returns>An awaitable task containing the gym session object or null</returns>
    Task<GymSession?> GetSession(int sessionId);

    /// <summary>
    /// Lists all of the sessions
    /// </summary>
    /// <returns>Awaitable task with the list of sessions as an IEnumerable</returns>
    Task<IEnumerable<GymSession>> ListSessions();

    /// <summary>
    /// Adds a new session
    /// </summary>
    /// <param name="session">The session to add</param>
    /// <returns>Awaitable task with the added session</returns>
    Task<GymSession> AddSession(GymSession session);

    /// <summary>
    /// Updates a session
    /// </summary>
    /// <param name="session">The updated session</param>
    /// <returns>Awaitable task with no result</returns>
    Task UpdateSession(GymSession session);

    /// <summary>
    /// Deletes a session from the database
    /// </summary>
    /// <param name="sessionId">The session ID of the session to delete</param>
    /// <returns>Awaitable task with no result</returns>
    Task DeleteSession(int sessionId);
    // Task AppendExercise(GymSession session);
}