using FastEndpoints;

public class GetAllEndpoint : Endpoint<EmptyModel, List<CoffeeOutModel>>
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

    public override async Task HandleAsync(EmptyModel req, CancellationToken ct)
    {
        List<CoffeeOutModel> response = await _useCase.Execute(req);

        await SendResultAsync(Results.Ok(response));
    }
}