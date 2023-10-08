public interface IGetAllUseCase : IUseCase<Guid?> { }

public sealed class GetAllUseCase : IGetAllUseCase
{
    private readonly IRepository _repository;
    private readonly IMapper<CoffeeEntity, CoffeeOutModel> _mapperOut;

    public GetAllUseCase(
        IRepository repository,
        IMapper<CoffeeEntity, CoffeeOutModel> mapperOut
    )
    {
        _mapperOut = mapperOut;
        _repository = repository;
    }

    public async Task<IResult> Execute(Guid? _)
    {
        List<CoffeeEntity> response = await _repository.GetAll();

        List<CoffeeOutModel> model = response.ConvertAll(_mapperOut.Mapper);

        return Results.Ok(model);
    }
}