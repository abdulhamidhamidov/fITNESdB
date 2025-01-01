using System.Net;
using Domain.Dtos.ClientDtos;
using Domain.Dtos.TrainerDtos;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ClientService(DataContext dataContext): IClientService
{
     public async Task<Response<string>> CteareClient(CreateClientDto request)
    {
        Client client = new Client();
        client.LastName = request.LastName;
        client.Email = request.Email;
        client.DateOfBirth = request.DateOfBirth;
        client.MemberShipStatus = request.MemberShipStatus;
        client.FirstName = request.FirstName;
        client.PhoneNumber = request.PhoneNumber;
        await dataContext.Clients.AddAsync(client);
        var res = await dataContext.SaveChangesAsync();
        if (res == 0) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        return new Response<string>("Created");
    }

    public async Task<Response<List<GetClientDto>>> GetClients()
    {
        var res = await dataContext.Clients.ToListAsync();
        var clients = res.Select(x=>new GetClientDto()
        {
            LastName = x.LastName,
            Email = x.Email,
            DateOfBirth = x.DateOfBirth,
            MemberShipStatus = x.MemberShipStatus,
            FirstName = x.FirstName,
            PhoneNumber = x.PhoneNumber
        }).ToList();
        if (clients.Count == null)
            return new Response<List<GetClientDto>>(HttpStatusCode.NotFound,"Not Found");
        return new Response<List<GetClientDto>>(clients);
    }

    public async Task<Response<GetClientDto>> GetClientById(int id)
    {
        var res = await dataContext.Clients.FirstOrDefaultAsync(x => x.Id == id);
        GetClientDto getClientDto = new GetClientDto();
        getClientDto.LastName = res.LastName;
        getClientDto.Email = res.Email;
        getClientDto.DateOfBirth = res.DateOfBirth;
        getClientDto.MemberShipStatus = res.MemberShipStatus;
        getClientDto.FirstName = res.FirstName;
        getClientDto.PhoneNumber = res.PhoneNumber;
        if(getClientDto==null)
            return new Response<GetClientDto>(HttpStatusCode.NotFound,"Not Found");
        return new Response<GetClientDto>(getClientDto);
        
    }

    public async Task<Response<string>> UpdateClient(UpdateClientDto request)
    {
        var res = await dataContext.Clients.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (res == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        res.LastName = request.LastName;
        res.Email = request.Email;
        res.MemberShipStatus = request.MemberShipStatus;
        res.FirstName = request.FirstName;
        res.PhoneNumber = request.PhoneNumber;
        var res2 = await dataContext.SaveChangesAsync();
        if (res2 == 0) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        return new Response<string>("Updated");
    }

    public async Task<Response<string>> DeleteClient(int id)
    {
        var client = await dataContext.Clients.FirstOrDefaultAsync(x => x.Id == id);
        if (client == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        dataContext.Clients.Remove(client);
        var res = await dataContext.SaveChangesAsync();
        if (res == 0) return new Response<string>(HttpStatusCode.NotFound, "Not Found");
        else return new Response<string>("Deleted");
    }
}