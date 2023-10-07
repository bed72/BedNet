using AutoMapper;

public sealed class GetByIdUseCase : IUseCase<Guid>
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public GetByIdUseCase(IMapper mapper, IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IResult> Execute(Guid data)
    {
        CoffeeEntity? response = await _repository.GetById(data);
        CoffeeOutModel model = _mapper.Map<CoffeeOutModel>(response);

        return response is null ? Results.NotFound() : Results.Ok(model);
    }
}