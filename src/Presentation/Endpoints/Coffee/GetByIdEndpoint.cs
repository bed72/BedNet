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

        if (response is not null) await SendResultAsync(Results.Ok(response));
        else await SendResultAsync(Results.NotFound(new FailureModel("Opss café não encontrado.")));
    }
}