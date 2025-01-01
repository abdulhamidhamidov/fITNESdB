using System.Net;
using Domain.Dtos.TrainerDtos;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TrainerService(DataContext dataContext) : ITrainerService
{
    public async Task<Response<string>> CteareTrainer(CreateTrainerDto request)
    {
        Trainer trainer = new Trainer();
        trainer.LastName = request.LastName;
        trainer.Experience = request.Experience;
        trainer.Specialization = request.Specialization;
        trainer.Status = request.Status;
        trainer.FirstName = request.FirstName;
        trainer.PhoneNumber = request.PhoneNumber;
        await dataContext.Trainers.AddAsync(trainer);
        var res = await dataContext.SaveChangesAsync();
        if (res == 0) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        return new Response<string>("Created");
    }

    public async Task<Response<List<GetTrainerDto>>> GetTrainers()
    {
        var res = await dataContext.Trainers.ToListAsync();
        var trainers = res.Select(x=>new GetTrainerDto()
        {
            LastName = x.LastName,
            Experience = x.Experience,
            Specialization = x.Specialization,
            Status = x.Status,
            FirstName = x.FirstName,
            PhoneNumber = x.PhoneNumber
        }).ToList();
        if (trainers.Count == null)
            return new Response<List<GetTrainerDto>>(HttpStatusCode.NotFound,"Not Found");
        return new Response<List<GetTrainerDto>>(trainers);
    }

    public async Task<Response<GetTrainerDto>> GetTrainerById(int id)
    {
        var res = await dataContext.Trainers.FirstOrDefaultAsync(x => x.Id == id);
        GetTrainerDto getTrainerDto = new GetTrainerDto();
        getTrainerDto.LastName = res.LastName;
        getTrainerDto.Experience = res.Experience;
        getTrainerDto.Specialization = res.Specialization;
        getTrainerDto.Status = res.Status;
        getTrainerDto.FirstName = res.FirstName;
        getTrainerDto.PhoneNumber = res.PhoneNumber;
        if(getTrainerDto==null)
            return new Response<GetTrainerDto>(HttpStatusCode.NotFound,"Not Found");
        return new Response<GetTrainerDto>(getTrainerDto);
        
    }

    public async Task<Response<string>> UpdateTrainer(UpdateTrainerDto request)
    {
        var res = await dataContext.Trainers.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (res == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        res.LastName = request.LastName;
        res.Experience = request.Experience;
        res.Specialization = request.Specialization;
        res.Status = request.Status;
        res.FirstName = request.FirstName;
        res.PhoneNumber = request.PhoneNumber;
        var res2 = await dataContext.SaveChangesAsync();
        if (res2 == 0) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        return new Response<string>("Updated");
    }

    public async Task<Response<string>> DeleteTrainer(int id)
    {
        var trainer = await dataContext.Trainers.FirstOrDefaultAsync(x => x.Id == id);
        if (trainer == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        dataContext.Trainers.Remove(trainer);
        var res = await dataContext.SaveChangesAsync();
        if (res == 0) return new Response<string>(HttpStatusCode.NotFound, "Not Found");
        else return new Response<string>("Deleted");
    }
}