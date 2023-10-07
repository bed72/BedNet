using AutoMapper;

public sealed class UpdateUseCase : IUseCase<Tuple<Guid, CoffeeInModel>>
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public UpdateUseCase(IMapper mapper, IRepository repository)
    {
        _mapper = mapper;
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
        CoffeeOutModel model = _mapper.Map<CoffeeOutModel>(response);

        return Results.Ok(model);
    }
}