using LanguageExt;

using Bed.src.domain.entities;

namespace Bed.src.domain.repositories;

public interface IRepository
{
    Task<Either<FailureEntity, CoffeeEntity>> Create(CoffeeEntity parameter, CancellationToken cancellation);
    Task<Either<FailureEntity, CoffeeEntity>> GetById(Guid parameter, CancellationToken cancellation);
    Task<Either<FailureEntity, List<CoffeeEntity>>> GetPaginete(int page, int limit, CancellationToken cancellation);
    Task<Either<FailureEntity, CoffeeEntity>> Update(Guid id, CoffeeEntity parameter, CancellationToken cancellation);
    Task<Either<FailureEntity, bool>> Delete(Guid parameter, CancellationToken cancellation);
}
