﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options): DbContext(options)
{
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<WorkoutSession> WorkoutSessions { get; set; }
}