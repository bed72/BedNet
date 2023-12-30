using LanguageExt;

using Bed.src.domain.usecases;
using Bed.src.domain.entities;
using Bed.src.application.models;
using Bed.src.domain.repositories;

namespace Bed.src.application.usecases;

public interface IGetByIdUseCase : IUseCase<Guid, Either<FailureOutModel, CoffeeOutModel>> { }

public sealed class GetByIdUseCase(IRepository repository) : IGetByIdUseCase
{
    private readonly IRepository _repository = repository;

    public async Task<Either<FailureOutModel, CoffeeOutModel>> Execute(
        Guid parameter,
        CancellationToken cancellation
    )
    {
        Either<FailureEntity, CoffeeEntity> response = await _repository.GetById(parameter, cancellation);

        return response
            .Map(mapper: (success) => (CoffeeOutModel)success)
            .MapLeft(mapper: (failure) => (FailureOutModel)failure);
    }
}
