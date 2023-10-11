using FastEndpoints;

public class CreateEndpoint : Endpoint<CoffeeInModel, CoffeeOutModel>
{
    private readonly ICreateUseCase _useCase;

    public CreateEndpoint(ICreateUseCase useCase)
    {
        _useCase = useCase;
    }

    public override void Configure()
    {
        Tags("Coffee");
        Verbs(Http.POST);
        AllowAnonymous();
        Routes("/coffee");
    }

    public override async Task HandleAsync(CoffeeInModel req, CancellationToken ct)
    {
        CoffeeOutModel? response = await _useCase.Execute(req);

        await SendResultAsync(Results.Created($"/coffe/{response.Id}", response));
    }
}