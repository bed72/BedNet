namespace Bed.src.domain.usecases;

public interface IUseCase<IN, OUT>
{
    public Task<OUT> Execute(IN parameter);
}
