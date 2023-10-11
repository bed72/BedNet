public interface IGetAllUseCase : IUseCase<List<CoffeeOutModel>, EmptyModel> { }

public sealed class GetAllUseCase : IGetAllUseCase
{
    private readonly IRepository _repository;

    public GetAllUseCase(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CoffeeOutModel>> Execute(EmptyModel _)
    {
        List<CoffeeEntity> response = await _repository.GetAll();

        List<CoffeeOutModel> model = response.ConvertAll(data => (CoffeeOutModel)data);

        return model;
    }
}