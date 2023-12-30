using LanguageExt;

using Bed.src.domain.entities;
using Bed.src.domain.usecases;
using Bed.src.domain.repositories;
using Bed.src.application.models;

namespace Bed.src.application.usecases;

public interface IDeleteUseCase : IUseCase<Guid, Either<FailureOutModel, bool>> { }

public sealed class DeleteUseCase(IRepository repository) : IDeleteUseCase
{
    private readonly IRepository _repository = repository;

    public async Task<Either<FailureOutModel, bool>> Execute(Guid parameter, CancellationToken cancellation)
    {
        Either<FailureEntity, bool> response = await _repository.Delete(parameter, cancellation);

        return response
            .Map(mapper: (success) => success)
            .MapLeft(mapper: (failure) => (FailureOutModel)failure);
    }
}
