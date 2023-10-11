using FastEndpoints;

public class GetByIdEndpoint : EndpointWithoutRequest<CoffeeOutModel>
{
    private readonly IGetByIdUseCase _useCase;

    public GetByIdEndpoint(IGetByIdUseCase useCase)
    {
        _useCase = useCase;
    }

    public override void Configure()
    {
        Tags("Coffee");
        Verbs(Http.GET);
        AllowAnonymous();
        Get("/coffee/{Guid}");
        Routes("/coffee/{Guid}");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        Guid id = Route<Guid>("Guid");
        CoffeeOutModel? response = await _useCase.Execute(id);

        await SendResultAsync(Results.Ok(response));
    }
}