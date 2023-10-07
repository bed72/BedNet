public sealed class GetCoffeesUseCase : IUseCase<Parameter>
{
    private readonly ICoffeeRepository _repository;

    public GetCoffeesUseCase(ICoffeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> Execute(Parameter _)
    {
        List<Coffee>? response = await _repository.GetCoffees();

        return response is null ? Results.NotFound() : Results.Ok(response);
    }
}