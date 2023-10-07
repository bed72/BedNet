

using MiniValidation;

public sealed class CreateCoffeeUseCase : IUseCase<CreateParameter>
{
    private readonly ICoffeeRepository _repository;

    public CreateCoffeeUseCase(ICoffeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> Execute(CreateParameter parameter)
    {
        if (!MiniValidator.TryValidate(parameter, out var failures))
            return Results.ValidationProblem(failures, statusCode: 422);

        Coffee response = await _repository.CreateCoffee(parameter.Data!);

        return Results.Created($"/coffe/{response.Id}", response);
    }
}