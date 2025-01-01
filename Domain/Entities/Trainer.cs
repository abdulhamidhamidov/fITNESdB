using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class Trainer
{
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string FirstName { get; set; }
    [Required,MaxLength(50)]
    public string LastName { get; set; }
    [Required,Phone]
    public string PhoneNumber { get; set; }
    [Required]
    public string Experience { get; set; }
    public TrainerStatus Status { get; set; }
    [MaxLength(100)]
    public string Specialization { get; set; }
}