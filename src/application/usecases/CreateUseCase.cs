using Bed.src.application.models;

using Bed.src.domain.usecases;
using Bed.src.domain.entities;
using Bed.src.domain.repositories;

namespace Bed.src.application.usecases;

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
