public interface IGetByIdUseCase : IUseCase<Guid> { }

public sealed class GetByIdUseCase : IGetByIdUseCase
{
    private readonly IRepository _repository;
    private readonly IMapper<CoffeeEntity, CoffeeOutModel> _mapperOut;

    public GetByIdUseCase(
        IRepository repository,
        IMapper<CoffeeEntity, CoffeeOutModel> mapperOut
    )
    {
        _mapperOut = mapperOut;
        _repository = repository;
    }

    public async Task<IResult> Execute(Guid data)
    {
        CoffeeEntity? response = await _repository.GetById(data);

        if (response is null) return Results.NotFound();

        CoffeeOutModel model = _mapperOut.Mapper(response);

        return Results.Ok(model);
    }
}