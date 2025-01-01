using Domain.Dtos.WorkoutSessionDtos;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("/api[controller]")]
public class WorkoutSessionController(IWorkoutSessionService trainerService): ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CteareWorkoutSession(CreateWorkoutSessionDto request)
    {
        return await trainerService.CteareWorkoutSession(request);
    }
    [HttpGet]
    public async Task<Response<List<GetWorkoutSessionDto>>> GetWorkoutSessions()
    {
        return await trainerService.GetWorkoutSessions();

    }
    [HttpPut]
    public async Task<Response<string>> UpdateWorkoutSession(UpdateWorkoutSessionDto request)
    {
        return await trainerService.UpdateWorkoutSession(request);

    }
    [HttpDelete]
    public async Task<Response<string>> DeleteWorkoutSession(int id)
    {
        return await trainerService.DeleteWorkoutSession(id);

    }
}