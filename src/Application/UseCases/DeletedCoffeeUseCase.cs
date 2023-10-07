using MiniValidation;

public sealed class DeleteCoffeeUseCase : IUseCase<DeleteParameter>
{
    private readonly ICoffeeRepository _repository;

    public DeleteCoffeeUseCase(ICoffeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> Execute(DeleteParameter parameter)
    {
        if (!MiniValidator.TryValidate(parameter, out var failures))
            return Results.ValidationProblem(failures, statusCode: 422);

        Coffee? response = await _repository.GetCoffee(parameter.Id);

        if (response is null) return Results.NotFound();

        await _repository.DeleteCoffee(response);

        return Results.NoContent();
    }
}