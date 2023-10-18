namespace Bed.Src.Domain.UseCases
{
    public interface IUseCase<R, M>
    {
        public Task<R> Execute(M data);
    }
}