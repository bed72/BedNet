using Bed.src.domain.entities;

using LanguageExt;

namespace Bed.src.domain.repositories;

public interface IRepository
{
    Task<Either<FailureEntity, CoffeeEntity>> Create(CoffeeEntity parameter);
    Task<Either<FailureEntity, CoffeeEntity>> GetById(Guid parameter);
    Task<Either<FailureEntity, List<CoffeeEntity>>> GetPaginete(int page, int limit);
    Task<Either<FailureEntity, CoffeeEntity>> Update(Guid id, CoffeeEntity parameter);
    Task<Either<FailureEntity, bool>> Delete(Guid parameter);
}
