using Domain.Dtos.TrainerDtos;
using Domain.Entities;
using Infrastructure.Responses;

namespace Infrastructure.Interfaces;

public interface ITrainerService
{
    public Task<Response<string>> CteareTrainer(CreateTrainerDto request);
    public Task<Response<List<GetTrainerDto>>> GetTrainers();
    public Task<Response<GetTrainerDto>> GetTrainerById(int id);
    public Task<Response<string>> UpdateTrainer(UpdateTrainerDto request);
    public Task<Response<string>> DeleteTrainer(int id);
}