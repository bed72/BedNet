using AutoMapper;

public sealed class CreateUseCase : IUseCase<CoffeeInModel>
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public CreateUseCase(IMapper mapper, IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IResult> Execute(CoffeeInModel data)
    {
        CoffeeEntity entity = _mapper.Map<CoffeeEntity>(data);
        CoffeeEntity response = await _repository.Create(entity);
        CoffeeOutModel model = _mapper.Map<CoffeeOutModel>(response);

        return Results.Created($"/coffe/{model.Id}", model);
    }
}