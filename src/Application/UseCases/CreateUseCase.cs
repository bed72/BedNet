public sealed class CreateUseCase : IUseCase<CoffeeInModel>
{
    private readonly IRepository _repository;
    private readonly IMapper<CoffeeInModel, CoffeeEntity> _mapperIn;
    private readonly IMapper<CoffeeEntity, CoffeeOutModel> _mapperOut;

    public CreateUseCase(
        IRepository repository,
        IMapper<CoffeeInModel, CoffeeEntity> mapperIn,
        IMapper<CoffeeEntity, CoffeeOutModel> mapperOut
    )
    {
        _mapperIn = mapperIn;
        _mapperOut = mapperOut;
        _repository = repository;
    }

    public async Task<IResult> Execute(CoffeeInModel data)
    {
        CoffeeEntity entity = _mapperIn.Mapper(data);
        CoffeeEntity response = await _repository.Create(entity);
        CoffeeOutModel model = _mapperOut.Mapper(response);

        return Results.Created($"/coffe/{model.Id}", model);
    }
}