public interface IGetAllUseCase : IUseCase<Guid?> { }

public sealed class GetAllUseCase : IGetAllUseCase
{
    private readonly IRepository _repository;

    public GetAllUseCase(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> Execute(Guid? _)
    {
        List<CoffeeEntity> response = await _repository.GetAll();

        List<CoffeeOutModel> model = response.ConvertAll(data => (CoffeeOutModel)data);

        return Results.Ok(model);
    }
}