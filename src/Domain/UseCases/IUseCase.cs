public interface IUseCase<M>
{
    public Task<IResult> Execute(M data);
}