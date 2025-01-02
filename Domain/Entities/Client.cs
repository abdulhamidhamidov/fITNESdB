using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class Client
{
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string FirstName { get; set; }
    [Required,MaxLength(50)]
    public string LastName { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required,EmailAddress]
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ClientMembershipStatus MemberShipStatus { get; set; }
    public List<WorkoutSession> WorkoutSessions { get; set; }

    // Id (int, primary key)
    // FirstName (string, required, max 50 characters)
    // LastName (string, required, max 50 characters)
    // PhoneNumber (string, required, валидация формата)
    // Email (string, валидация формата)
    // DateOfBirth (DateTime)
    // MembershipStatus (string)
}