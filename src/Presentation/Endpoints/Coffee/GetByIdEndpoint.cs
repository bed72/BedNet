using FastEndpoints;

public class GetByIdEndpoint : Endpoint<Guid, CoffeeOutModel>
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
        Get("/coffee/{EmptyModel}");
        Routes("/coffee/{id:guid}");
    }

    public override async Task HandleAsync(Guid req, CancellationToken ct)
    {
        CoffeeOutModel? response = await _useCase.Execute(req);

        await SendResultAsync(Results.Ok(response));
    }
}