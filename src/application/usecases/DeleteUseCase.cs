using LanguageExt;

using Bed.src.domain.entities;
using Bed.src.domain.usecases;
using Bed.src.domain.repositories;
using Bed.src.application.models;

namespace Bed.src.application.usecases;

public interface IDeleteUseCase : IUseCase<Guid, Either<FailureOutModel, bool>> { }

public sealed class DeleteUseCase : IDeleteUseCase
{
    private readonly IRepository _repository;

    public DeleteUseCase(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Either<FailureOutModel, bool>> Execute(Guid parameter)
    {
        Either<FailureEntity, bool> response = await _repository.Delete(parameter);

        return response
            .Map(mapper: (success) => success)
            .MapLeft(mapper: (failure) => (FailureOutModel)failure);
    }
}
