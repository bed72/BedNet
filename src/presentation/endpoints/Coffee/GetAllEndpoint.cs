using FastEndpoints;

using Bed.src.application.models;
using Bed.src.application.usecases;

namespace Bed.src.presentation.endpoints.coffee;

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
        int page = Query<int>("page", isRequired: false);
        int limit = Query<int>("limit", isRequired: false);

        List<CoffeeOutModel> response = await _useCase.Execute(new Tuple<int, int>(page, limit));

        await SendResultAsync(Results.Ok(response));
    }
}
