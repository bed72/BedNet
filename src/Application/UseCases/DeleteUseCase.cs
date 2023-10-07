public sealed class DeleteUseCase : IUseCase<Guid>
{
    private readonly IRepository _repository;

    public DeleteUseCase(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> Execute(Guid data)
    {

        CoffeeEntity? response = await _repository.GetById(data);

        if (response is null) return Results.NotFound();

        await _repository.Delete(response);

        return Results.NoContent();
    }
}