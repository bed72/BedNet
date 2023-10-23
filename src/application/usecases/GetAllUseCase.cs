using Bed.src.application.models;

using Bed.src.domain.entities;
using Bed.src.domain.usecases;
using Bed.src.domain.repositories;

namespace Bed.src.application.usecases;

public interface IGetAllUseCase : IUseCase<List<CoffeeOutModel>, Tuple<int, int>> { }

public sealed class GetAllUseCase : IGetAllUseCase
{
    private readonly IRepository _repository;

    public GetAllUseCase(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CoffeeOutModel>> Execute(Tuple<int, int> data)
    {
        List<CoffeeEntity> response = await _repository.GetAll(data);

        List<CoffeeOutModel> model = response.ConvertAll(data => (CoffeeOutModel)data);

        return model;
    }
}
