using Domain.Enums;

namespace Domain.Dtos.WorkoutSessionDtos;

public class UpdateWorkoutSessionDto
{
    public int Id { get; set; }
    public int TrainerId { get; set; }
    public int WorkoutId { get; set; }
    public int ClientId { get; set; }
    public DateTime SessionDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public WorkoutSessionStatus Status { get; set; }
    public int MaxCapacity { get; set; }
    public int CurrentParticipants { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
}