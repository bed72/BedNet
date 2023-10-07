using MiniValidation;

public sealed class GetCoffeeUseCase : IUseCase<GetParameter>
{
    private readonly ICoffeeRepository _repository;

    public GetCoffeeUseCase(ICoffeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> Execute(GetParameter parameter)
    {
        if (!MiniValidator.TryValidate(parameter, out var failures))
            return Results.ValidationProblem(failures, statusCode: 422);

        Coffee? response = await _repository.GetCoffee(parameter.Id);

        return response is null ? Results.NotFound() : Results.Ok(response);
    }
}