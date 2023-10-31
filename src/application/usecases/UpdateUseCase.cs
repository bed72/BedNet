using LanguageExt;

using Bed.src.domain.entities;
using Bed.src.domain.usecases;
using Bed.src.application.models;
using Bed.src.domain.repositories;

namespace Bed.src.application.usecases;

public interface IUpdateUseCase : IUseCase<Tuple<Guid, CoffeeInModel>, Either<FailureOutModel, CoffeeOutModel>> { }

public sealed class UpdateUseCase : IUpdateUseCase
{
    private readonly IRepository _repository;

    public UpdateUseCase(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Either<FailureOutModel, CoffeeOutModel>> Execute(Tuple<Guid, CoffeeInModel> parameter)
    {
        Guid id = parameter.Item1;
        CoffeeInModel model = parameter.Item2;

        CoffeeEntity entity = (CoffeeEntity)model;
        entity.Updated = DateTime.Now.ToUniversalTime();

        Either<FailureEntity, CoffeeEntity> response = await _repository.Update(id, entity);

        return response
            .Map(mapper: (success) => (CoffeeOutModel)success)
            .MapLeft(mapper: (failure) => (FailureOutModel)failure);
    }
}
