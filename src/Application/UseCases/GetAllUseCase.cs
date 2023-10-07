using AutoMapper;

public sealed class GetAllUseCase : IUseCase<Guid?>
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public GetAllUseCase(IMapper mapper, IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IResult> Execute(Guid? _)
    {
        List<CoffeeEntity> response = await _repository.GetAll();
        CoffeeOutModel model = _mapper.Map<CoffeeOutModel>(response);

        return Results.Ok(model);
    }
}