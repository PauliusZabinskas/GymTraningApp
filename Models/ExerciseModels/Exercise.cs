using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Models.ExerciseModels;

/// <summary>
/// Fields should not be nullable. You should create DTOs
/// instead.
/// </summary>
public class Exercise
{
    public int? Id { get; set; }
    public string? Name { get; set; } = null!;
    
    [ForeignKey(nameof(GymSessionID))]
    public int? GymSessionID { get; set; }
}