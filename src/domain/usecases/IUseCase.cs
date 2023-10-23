namespace Bed.src.domain.usecases;

public interface IUseCase<R, M>
{
    public Task<R> Execute(M data);
}
