using GymApp.Models;
using GymApp.Models.ExerciseModels;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<GymSession> GymSessions { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Configuration depends on the behavior you want.
        builder.Entity<GymSession>()
        .HasMany(session => session.Exercises);
    }
}