namespace GymApp.Models.ExerciseModels;

/// <summary>
/// Fields should not be nullable. You should create DTOs
/// instead.
/// </summary>
public class GymSession
{
    public int? Id { get; set; }
    public string? OwnerId { get; set; } = null!;
    public string? Title { get; set; } = null!;
    public IEnumerable<Exercise>? Exercises { get; set; } = new List<Exercise>();
}