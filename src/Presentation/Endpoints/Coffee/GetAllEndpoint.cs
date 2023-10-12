using FastEndpoints;

public class GetAllEndpoint : EndpointWithoutRequest<List<CoffeeOutModel>>
{
    private readonly IGetAllUseCase _useCase;

    public GetAllEndpoint(IGetAllUseCase useCase)
    {
        _useCase = useCase;
    }

    public override void Configure()
    {
        Tags("Coffee");
        Verbs(Http.GET);
        AllowAnonymous();
        Routes("/coffee");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        List<CoffeeOutModel> response = await _useCase.Execute(null);

        await SendResultAsync(Results.Ok(response));
    }
}