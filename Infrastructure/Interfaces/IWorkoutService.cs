using Domain.Dtos.WorkoutDtos;
using Domain.Entities;
using Infrastructure.Responses;

namespace Infrastructure.Interfaces;

public interface IWorkoutService
{
    public Task<Response<string>> CteareWorkout(CreateWorkoutDto request);
    public Task<Response<List<GetWorkoutDto>>> GetWorkouts();
    public Task<Response<GetWorkoutDto>> GetWorkoutById(int id);
    public Task<Response<string>> UpdateWorkout(UpdateWorkoutDto request);
    public Task<Response<string>> DeleteWorkout(int id);
}