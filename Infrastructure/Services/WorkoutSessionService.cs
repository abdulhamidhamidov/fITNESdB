using System.Net;
using Domain.Dtos.WorkoutSessionDtos;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class WorkoutSessionService(DataContext dataContext): IWorkoutSessionService
{
     public async Task<Response<string>> CteareWorkoutSession(CreateWorkoutSessionDto request)
    {
        WorkoutSession workoutSession = new WorkoutSession();
        workoutSession.Status = request.Status;
        workoutSession.WorkoutId = request.WorkoutId;
        workoutSession.ClientId = request.ClientId;
        workoutSession.TrainerId = request.TrainerId;
        workoutSession.Comment = request.Comment;
        workoutSession.CreatedAt = request.CreatedAt;
        workoutSession.CurrentParticipants = request.CurrentParticipants;
        workoutSession.EndTime = request.EndTime;
        workoutSession.StartTime = request.StartTime;
        workoutSession.MaxCapacity = request.MaxCapacity;
        workoutSession.SessionDate = request.SessionDate;

        await dataContext.WorkoutSessions.AddAsync(workoutSession);
        var res = await dataContext.SaveChangesAsync();
        if (res == 0) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        return new Response<string>("Created");
    }

    public async Task<Response<List<GetWorkoutSessionDto>>> GetWorkoutSessions()
    {
        var res = await dataContext.WorkoutSessions.ToListAsync();
        var workoutSessions = res.Select(x=>new GetWorkoutSessionDto()
        {
            Status = x.Status,
            WorkoutId = x.WorkoutId,
            ClientId = x.ClientId,
            TrainerId = x.TrainerId,
            Comment = x.Comment,
            CreatedAt = x.CreatedAt,
            CurrentParticipants = x.CurrentParticipants,
            EndTime = x.EndTime,
            StartTime = x.StartTime,
            MaxCapacity = x.MaxCapacity,
            SessionDate = x.SessionDate
        }).ToList();
        if (workoutSessions.Count == null)
            return new Response<List<GetWorkoutSessionDto>>(HttpStatusCode.NotFound,"Not Found");
        return new Response<List<GetWorkoutSessionDto>>(workoutSessions);
    }

    public async Task<Response<string>> UpdateWorkoutSession(UpdateWorkoutSessionDto request)
    {
        var res = await dataContext.WorkoutSessions.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (res == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        res.Status = request.Status;
        res.WorkoutId = request.WorkoutId;
        res.ClientId = request.ClientId;
        res.TrainerId = request.TrainerId;
        res.Comment = request.Comment;
        res.CreatedAt = request.CreatedAt;
        res.CurrentParticipants = request.CurrentParticipants;
        res.EndTime = request.EndTime;
        res.StartTime = request.StartTime;
        res.MaxCapacity = request.MaxCapacity;
        res.SessionDate = request.SessionDate;
        var res2 = await dataContext.SaveChangesAsync();
        if (res2 == 0) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        return new Response<string>("Updated");
    }

    public async Task<Response<string>> DeleteWorkoutSession(int id)
    {
        var workoutSession = await dataContext.WorkoutSessions.FirstOrDefaultAsync(x => x.Id == id);
        if (workoutSession == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        dataContext.WorkoutSessions.Remove(workoutSession);
        var res = await dataContext.SaveChangesAsync();
        if (res == 0) return new Response<string>(HttpStatusCode.NotFound, "Not Found");
        else return new Response<string>("Deleted");
    }
}

