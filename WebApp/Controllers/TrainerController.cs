using Domain.Dtos.TrainerDtos;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("/api[controller]")]
public class TrainerController(ITrainerService trainerService): ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CteareTrainer(CreateTrainerDto request)
    {
        return await trainerService.CteareTrainer(request);
    }
    [HttpGet]
    public async Task<Response<List<GetTrainerDto>>> GetTrainers()
    {
        return await trainerService.GetTrainers();

    }
    [HttpGet("/Trainer-By-Id")]
    public async Task<Response<GetTrainerDto>> GetTrainerById(int id)
    {
        return await trainerService.GetTrainerById(id);

    }
    [HttpPut]
    public async Task<Response<string>> UpdateTrainer(UpdateTrainerDto request)
    {
        return await trainerService.UpdateTrainer(request);

    }
    [HttpDelete]
    public async Task<Response<string>> DeleteTrainer(int id)
    {
        return await trainerService.DeleteTrainer(id);

    }
}