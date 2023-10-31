using Bed.src.application.models;

using Bed.src.domain.entities;
using Bed.src.domain.usecases;
using Bed.src.domain.repositories;

using LanguageExt;

namespace Bed.src.application.usecases;

public interface ICreateUseCase : IUseCase<CoffeeInModel, Either<FailureOutModel, CoffeeOutModel>> { }

public sealed class CreateUseCase : ICreateUseCase
{
    private readonly IRepository _repository;

    public CreateUseCase(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Either<FailureOutModel, CoffeeOutModel>> Execute(CoffeeInModel parameter)
    {
        CoffeeEntity entity = (CoffeeEntity)parameter;
        entity.Created = DateTime.Now.ToUniversalTime();

        Either<FailureEntity, CoffeeEntity> response = await _repository.Create(entity);

        return response
            .Map(mapper: (success) => (CoffeeOutModel)success)
            .MapLeft(mapper: (failure) => (FailureOutModel)failure);
    }
}
