using Domain.Dtos.WorkoutSessionDtos;
using Domain.Entities;
using Infrastructure.Responses;

namespace Infrastructure.Interfaces;

public interface IWorkoutSessionService
{
    public Task<Response<string>> CteareWorkoutSession(CreateWorkoutSessionDto request);
    public Task<Response<List<GetWorkoutSessionDto>>> GetWorkoutSessions();
    public Task<Response<string>> UpdateWorkoutSession(UpdateWorkoutSessionDto request);
    public Task<Response<string>> DeleteWorkoutSession(int id);
}