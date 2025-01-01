using Domain.Dtos.ClientDtos;
using Domain.Dtos.TrainerDtos;
using Domain.Entities;
using Infrastructure.Responses;

namespace Infrastructure.Interfaces;

public interface IClientService
{
    public Task<Response<string>> CteareClient(CreateClientDto request);
    public Task<Response<List<GetClientDto>>> GetClients();
    public Task<Response<GetClientDto>> GetClientById(int id);
    public Task<Response<string>> UpdateClient(UpdateClientDto request);
    public Task<Response<string>> DeleteClient(int id);
}