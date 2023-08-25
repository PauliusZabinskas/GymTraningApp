using GymApp.Models;
using GymApp.Models.ExerciseModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Database;

public class ApplicationDbContext : IdentityDbContext
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

        base.OnModelCreating(builder);
    }
}