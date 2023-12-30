using LanguageExt;

using Bed.src.domain.entities;
using Bed.src.domain.usecases;
using Bed.src.application.models;
using Bed.src.domain.repositories;

namespace Bed.src.application.usecases;

public interface IUpdateUseCase : IUseCase<Tuple<Guid, CoffeeInModel>, Either<FailureOutModel, CoffeeOutModel>> { }

public sealed class UpdateUseCase(IRepository repository) : IUpdateUseCase
{
    private readonly IRepository _repository = repository;

    public async Task<Either<FailureOutModel, CoffeeOutModel>> Execute(
        Tuple<Guid, CoffeeInModel> parameter,
        CancellationToken cancellation
    )
    {
        Either<FailureEntity, CoffeeEntity> response = await
            _repository.Update(parameter.Item1, (CoffeeEntity)parameter.Item2, cancellation);

        return response
            .Map(mapper: (success) => (CoffeeOutModel)success)
            .MapLeft(mapper: (failure) => (FailureOutModel)failure);
    }
}
