using Domain.Dtos.ClientDtos;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("/api[controller]")]
public class ClientController(IClientService trainerService): ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CteareClient(CreateClientDto request)
    {
        return await trainerService.CteareClient(request);
    }
    [HttpGet]
    public async Task<Response<List<GetClientDto>>> GetClients()
    {
        return await trainerService.GetClients();

    }
    [HttpGet("/Client-By-Id")]
    public async Task<Response<GetClientDto>> GetClientById(int id)
    {
        return await trainerService.GetClientById(id);

    }
    [HttpPut]
    public async Task<Response<string>> UpdateClient(UpdateClientDto request)
    {
        return await trainerService.UpdateClient(request);

    }
    [HttpDelete]
    public async Task<Response<string>> DeleteClient(int id)
    {
        return await trainerService.DeleteClient(id);

    }
}