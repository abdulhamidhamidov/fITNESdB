using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;

public class WorkoutSession
{
    public int Id { get; set; }
    [ForeignKey("Trainer")]
    public int TrainerId { get; set; }
    [ForeignKey("Workout")]
    public int WorkoutId { get; set; }
    [ForeignKey("Client")]
    public int ClientId { get; set; }
    public DateTime SessionDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public WorkoutSessionStatus Status { get; set; }
    public int MaxCapacity { get; set; }
    public int CurrentParticipants { get; set; }
    [MaxLength(200)]
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public Trainer Trainer { get; set; }
    public Workout Workout { get; set; }

    // Id (int, primary key)
    // TrainerId (foreign key)
    // WorkoutId (foreign key)
    // SessionDate (DateTime, не в прошлом)
    // StartTime (TimeSpan, рабочие часы 7:00-23:00)
    // EndTime (TimeSpan, рабочие часы 7:00-23:00)
    // Status (string)
    // MaxCapacity (int)
    // CurrentParticipants (int)
    // Comment (string, max 200 characters)
    // CreatedAt (DateTime)
}