using FastEndpoints;

using Bed.src.application.models;
using Bed.src.application.usecases;

namespace Bed.src.presentation.endpoints.coffee;

public class UpdateEndpoint : Endpoint<CoffeeInModel, CoffeeOutModel>
{
    private readonly IUpdateUseCase _useCase;

    public UpdateEndpoint(IUpdateUseCase useCase)
    {
        _useCase = useCase;
    }

    public override void Configure()
    {
        Tags("Coffee");
        Verbs(Http.PUT);
        AllowAnonymous();
        Put("/coffee/{Guid}");
        Routes("/coffee/{Guid}");
    }

    public override async Task HandleAsync(CoffeeInModel req, CancellationToken ct)
    {
        Guid id = Route<Guid>("Guid");
        CoffeeOutModel? response = await _useCase.Execute(new Tuple<Guid, CoffeeInModel>(id, req));

        if (response is not null) await SendResultAsync(Results.Ok(response));
        else await SendResultAsync(Results.BadRequest(new FailureModel("Opss não conseguimos atualizar seu café.")));
    }
}
