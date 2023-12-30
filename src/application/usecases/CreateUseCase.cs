using LanguageExt;

using Bed.src.application.models;

using Bed.src.domain.entities;
using Bed.src.domain.usecases;
using Bed.src.domain.repositories;

namespace Bed.src.application.usecases;

public interface ICreateUseCase : IUseCase<CoffeeInModel, Either<FailureOutModel, CoffeeOutModel>> { }

public sealed class CreateUseCase(IRepository repository) : ICreateUseCase
{
    private readonly IRepository _repository = repository;

    public async Task<Either<FailureOutModel, CoffeeOutModel>> Execute(
        CoffeeInModel parameter,
        CancellationToken cancellation
    )
    {
        Either<FailureEntity, CoffeeEntity> response =
            await _repository.Create((CoffeeEntity)parameter, cancellation);

        return response
            .Map(mapper: (success) => (CoffeeOutModel)success)
            .MapLeft(mapper: (failure) => (FailureOutModel)failure);
    }
}
