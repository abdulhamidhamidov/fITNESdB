using Domain.Enums;

namespace Domain.Dtos.ClientDtos;

public class GetClientDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ClientMembershipStatus MemberShipStatus { get; set; }
}