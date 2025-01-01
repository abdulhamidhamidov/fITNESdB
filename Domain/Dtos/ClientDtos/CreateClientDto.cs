using Domain.Enums;

namespace Domain.Dtos.ClientDtos;

public class CreateClientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ClientMembershipStatus MemberShipStatus { get; set; }
}