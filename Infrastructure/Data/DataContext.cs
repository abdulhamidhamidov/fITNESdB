using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options): DbContext(options)
{
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<WorkoutSession> WorkoutSessions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Workout>().HasMany<WorkoutSession>(c => c.WorkoutSessions).WithOne(a => a.Workout).HasForeignKey(a => a.WorkoutId);
        modelBuilder.Entity<Trainer>().HasMany<WorkoutSession>(c => c.WorkoutSessions).WithOne(a => a.Trainer).HasForeignKey(a => a.TrainerId);
        modelBuilder.Entity<Client>().HasMany<WorkoutSession>(c => c.WorkoutSessions).WithOne(a => a.Client).HasForeignKey(a => a.ClientId);

    }
}