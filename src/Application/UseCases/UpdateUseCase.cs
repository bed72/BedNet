public sealed class UpdateUseCase : IUseCase<Tuple<Guid, CoffeeInModel>>
{
    private readonly IRepository _repository;
    private readonly IMapper<CoffeeEntity, CoffeeOutModel> _mapperOut;

    public UpdateUseCase(
        IRepository repository,
        IMapper<CoffeeEntity, CoffeeOutModel> mapperOut
    )
    {
        _mapperOut = mapperOut;
        _repository = repository;
    }

    public async Task<IResult> Execute(Tuple<Guid, CoffeeInModel> data)
    {
        CoffeeEntity? coffee = await _repository.GetById(data.Item1);

        if (coffee is null) return Results.NotFound();

        coffee.Name = data.Item2.Name;
        coffee.Price = data.Item2.Price;
        coffee.Updated = DateTime.Now;

        CoffeeEntity response = await _repository.Update(coffee);
        CoffeeOutModel model = _mapperOut.Mapper(response);

        return Results.Ok(model);
    }
}