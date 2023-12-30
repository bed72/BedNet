using LanguageExt;

using Bed.src.domain.entities;
using Bed.src.domain.usecases;
using Bed.src.application.models;
using Bed.src.domain.repositories;

namespace Bed.src.application.usecases;

public interface IGetPaginateUseCase : IUseCase<Tuple<int, int>, Either<FailureOutModel, List<CoffeeOutModel>>> { }

public sealed class GetPaginateUseCase(IRepository repository) : IGetPaginateUseCase
{
    private readonly IRepository _repository = repository;

    public async Task<Either<FailureOutModel, List<CoffeeOutModel>>> Execute(
        Tuple<int, int> parameter,
        CancellationToken cancellation
    )
    {
        Either<FailureEntity, List<CoffeeEntity>> response =
            await _repository.GetPaginete(parameter.Item1, parameter.Item2, cancellation);

        return response
            .Map(mapper: (success) => success.ConvertAll(data => (CoffeeOutModel)data))
            .MapLeft(mapper: (failure) => (FailureOutModel)failure);
    }
}
