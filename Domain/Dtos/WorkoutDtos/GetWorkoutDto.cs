using Domain.Enums;

namespace Domain.Dtos.WorkoutDtos;

public class GetWorkoutDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public int MaxParticipants { get; set; }
    public WorkoutDifficulty Difficulty { get; set; }
    public bool IsActive { get; set; }
}