using Bed.src.application.models;

using Bed.src.domain.usecases;
using Bed.src.domain.entities;
using Bed.src.domain.repositories;

namespace Bed.src.application.usecases;

public interface IGetByIdUseCase : IUseCase<CoffeeOutModel?, Guid> { }

public sealed class GetByIdUseCase : IGetByIdUseCase
{
    private readonly IRepository _repository;

    public GetByIdUseCase(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<CoffeeOutModel?> Execute(Guid data)
    {
        CoffeeEntity? response = await _repository.GetById(data);

        if (response is null) return null;

        CoffeeOutModel model = (CoffeeOutModel)response;

        return model;
    }
}
