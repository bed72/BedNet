public interface ICreateUseCase : IUseCase<CoffeeOutModel, CoffeeInModel> { }

public sealed class CreateUseCase : ICreateUseCase
{
    private readonly IRepository _repository;

    public CreateUseCase(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<CoffeeOutModel> Execute(CoffeeInModel data)
    {
        CoffeeEntity entity = (CoffeeEntity)data;
        CoffeeEntity response = await _repository.Create(entity);
        CoffeeOutModel model = (CoffeeOutModel)response;

        return model; // Results.Created($"/coffe/{model.Id}", model);
    }
}