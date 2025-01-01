using Domain.Dtos.WorkoutDtos;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("/api[controller]")]
public class WorkoutController(IWorkoutService trainerService): ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CteareWorkout(CreateWorkoutDto request)
    {
        return await trainerService.CteareWorkout(request);
    }
    [HttpGet]
    public async Task<Response<List<GetWorkoutDto>>> GetWorkouts()
    {
        return await trainerService.GetWorkouts();

    }
    [HttpGet("/Workout-By-Id")]
    public async Task<Response<GetWorkoutDto>> GetWorkoutById(int id)
    {
        return await trainerService.GetWorkoutById(id);

    }
    [HttpPut]
    public async Task<Response<string>> UpdateWorkout(UpdateWorkoutDto request)
    {
        return await trainerService.UpdateWorkout(request);

    }
    [HttpDelete]
    public async Task<Response<string>> DeleteWorkout(int id)
    {
        return await trainerService.DeleteWorkout(id);

    }
}