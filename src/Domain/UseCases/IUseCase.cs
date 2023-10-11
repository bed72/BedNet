public interface IUseCase<R, M>
{
    public Task<R> Execute(M data);
}