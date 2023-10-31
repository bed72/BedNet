using LanguageExt;

using Bed.src.domain.entities;
using Bed.src.domain.usecases;
using Bed.src.application.models;
using Bed.src.domain.repositories;

namespace Bed.src.application.usecases;

public interface IGetPaginateUseCase : IUseCase<PaginateInModel, Either<FailureOutModel, List<CoffeeOutModel>>> { }

public sealed class GetPaginateUseCase : IGetPaginateUseCase
{
    private readonly IRepository _repository;

    public GetPaginateUseCase(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Either<FailureOutModel, List<CoffeeOutModel>>> Execute(PaginateInModel parameter)
    {
        Either<FailureEntity, List<CoffeeEntity>> response =
            await _repository.GetPaginete(parameter.page, parameter.limit);

        return response
            .Map(mapper: (success) => success.ConvertAll(data => (CoffeeOutModel)data))
            .MapLeft(mapper: (failure) => (FailureOutModel)failure);
    }
}
