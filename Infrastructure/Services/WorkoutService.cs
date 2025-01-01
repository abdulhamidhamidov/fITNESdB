using System.Net;
using Domain.Dtos.WorkoutDtos;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class WorkoutService(DataContext dataContext): IWorkoutService
{
    public async Task<Response<string>> CteareWorkout(CreateWorkoutDto request)
    {
        Workout client = new Workout();
        client.Description=request.Description;
        client.Difficulty=request.Difficulty;
        client.Duration=request.Duration;
        client.MaxParticipants=request.MaxParticipants;
        client.Name=request.Name;
        client.IsActive=request.IsActive;
        
        await dataContext.Workouts.AddAsync(client);
        var res = await dataContext.SaveChangesAsync();
        if (res == 0) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        return new Response<string>("Created");
    }

    public async Task<Response<List<GetWorkoutDto>>> GetWorkouts()
    {
        var res = await dataContext.Workouts.ToListAsync();
        var clients = res.Select(x=>new GetWorkoutDto()
        {
            Description=x.Description,
            Difficulty=x.Difficulty,
            Duration=x.Duration,
            MaxParticipants=x.MaxParticipants,
            Name=x.Name,
            IsActive=x.IsActive
        }).ToList();
        if (clients.Count == null)
            return new Response<List<GetWorkoutDto>>(HttpStatusCode.NotFound,"Not Found");
        return new Response<List<GetWorkoutDto>>(clients);
    }

    public async Task<Response<GetWorkoutDto>> GetWorkoutById(int id)
    {
        var res = await dataContext.Workouts.FirstOrDefaultAsync(x => x.Id == id);
        GetWorkoutDto getWorkoutDto = new GetWorkoutDto();
        getWorkoutDto.Description=res.Description;
        getWorkoutDto.Difficulty=res.Difficulty;
        getWorkoutDto.Duration=res.Duration;
        getWorkoutDto.MaxParticipants=res.MaxParticipants;
        getWorkoutDto.Name=res.Name;
        getWorkoutDto.IsActive=res.IsActive;
        if(getWorkoutDto==null)
            return new Response<GetWorkoutDto>(HttpStatusCode.NotFound,"Not Found");
        return new Response<GetWorkoutDto>(getWorkoutDto);
        
    }

    public async Task<Response<string>> UpdateWorkout(UpdateWorkoutDto request)
    {
        var res = await dataContext.Workouts.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (res == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        res.Description=request.Description;
        res.Difficulty=request.Difficulty;
        res.Duration=request.Duration;
        res.MaxParticipants=request.MaxParticipants;
        res.Name=request.Name;
        res.IsActive=request.IsActive;
        var res2 = await dataContext.SaveChangesAsync();
        if (res2 == 0) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        return new Response<string>("Updated");
    }

    public async Task<Response<string>> DeleteWorkout(int id)
    {
        var client = await dataContext.Workouts.FirstOrDefaultAsync(x => x.Id == id);
        if (client == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        dataContext.Workouts.Remove(client);
        var res = await dataContext.SaveChangesAsync();
        if (res == 0) return new Response<string>(HttpStatusCode.NotFound, "Not Found");
        else return new Response<string>("Deleted");
    }
}