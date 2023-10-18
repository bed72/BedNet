using Bed.Src.Domain.UseCases;
using Bed.Src.Domain.Entities;
using Bed.Src.Application.Models;
using Bed.Src.Domain.Repositories;

namespace Bed.Src.Application.UseCases
{
    public interface ICreateUseCase : IUseCase<CoffeeOutModel, CoffeeInModel> { }

    public sealed class CreateUseCase : ICreateUseCase
    {
        private readonly IRepository _repository;

        public CreateUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<CoffeeOutModel> Execute(CoffeeInModel data)
        {
            CoffeeEntity entity = (CoffeeEntity)data;
            CoffeeEntity response = await _repository.Create(entity);
            CoffeeOutModel model = (CoffeeOutModel)response;

            return model;
        }
    }
}