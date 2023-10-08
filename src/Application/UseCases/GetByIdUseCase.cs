public interface IGetByIdUseCase : IUseCase<Guid> { }

public sealed class GetByIdUseCase : IGetByIdUseCase
{
    private readonly IRepository _repository;

    public GetByIdUseCase(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> Execute(Guid data)
    {
        CoffeeEntity? response = await _repository.GetById(data);

        if (response is null) return Results.NotFound();

        CoffeeOutModel model = (CoffeeOutModel)response;

        return Results.Ok(model);
    }
}