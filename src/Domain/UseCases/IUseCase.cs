public interface IUseCase<P> where P : Parameter
{
    public Task<IResult> Execute(P parameter);
}