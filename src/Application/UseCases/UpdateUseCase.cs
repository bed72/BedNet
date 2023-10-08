public interface IUpdateUseCase : IUseCase<Tuple<Guid, CoffeeInModel>> { }

public sealed class UpdateUseCase : IUpdateUseCase
{
    private readonly IRepository _repository;

    public UpdateUseCase(IRepository repository)
    {
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
        CoffeeOutModel model = (CoffeeOutModel)response;

        return Results.Ok(model);
    }
}