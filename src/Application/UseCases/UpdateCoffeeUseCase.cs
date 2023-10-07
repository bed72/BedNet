using MiniValidation;

public sealed class UpdateCoffeeUseCase : IUseCase<UpdateParameter>
{
    private readonly ICoffeeRepository _repository;

    public UpdateCoffeeUseCase(ICoffeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> Execute(UpdateParameter parameter)
    {
        if (!MiniValidator.TryValidate(parameter, out var failures))
            return Results.ValidationProblem(failures, statusCode: 422);

        Coffee? response = await _repository.GetCoffee(parameter.Id);

        if (response is null) return Results.NotFound();

        response.Name = parameter?.Data?.Name;
        response.Price = parameter?.Data?.Price;
        response.Updated = DateTime.Now;

        await _repository.UpdateCoffee(response);

        return Results.NoContent();
    }
}