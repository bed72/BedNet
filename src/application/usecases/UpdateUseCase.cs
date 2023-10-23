using Bed.src.application.models;

using Bed.src.domain.entities;
using Bed.src.domain.usecases;
using Bed.src.domain.repositories;

namespace Bed.src.application.usecases;

public interface IUpdateUseCase : IUseCase<CoffeeOutModel?, Tuple<Guid, CoffeeInModel>> { }

public sealed class UpdateUseCase : IUpdateUseCase
{
    private readonly IRepository _repository;

    public UpdateUseCase(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<CoffeeOutModel?> Execute(Tuple<Guid, CoffeeInModel> data)
    {
        CoffeeEntity? coffee = await _repository.GetById(data.Item1);

        if (coffee is null) return null;

        coffee.Name = data.Item2.Name;
        coffee.Price = data.Item2.Price;
        coffee.Updated = DateTime.Now.ToUniversalTime();

        CoffeeEntity response = await _repository.Update(coffee);
        CoffeeOutModel model = (CoffeeOutModel)response;

        return model;
    }
}
