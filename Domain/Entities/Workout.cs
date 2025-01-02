using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class Workout
{
    public int Id { get; set; }
    [Required,MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    public int Duration { get; set; }
    public int MaxParticipants { get; set; }
    public WorkoutDifficulty Difficulty { get; set; }
    public bool IsActive { get; set; }
    public List<WorkoutSession> WorkoutSessions { get; set; }


    // Id (int, primary key)
    // Name (string, required, max 100 characters)
    // Description (string, max 500 characters)
    // Duration (int, время в минутах, больше 0)
    // MaxParticipants (int, больше 0)
    // Difficulty (string)
    // IsActive (bool)
}