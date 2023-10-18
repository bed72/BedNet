using FastEndpoints;

using Bed.Src.Application.Models;
using Bed.Src.Application.UseCases;

namespace Bed.Src.Presentation.Endpoints.Coffee
{
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

            if (response is not null) await SendResultAsync(Results.Created($"/coffe/{response?.Id}", response));
            else await SendResultAsync(Results.BadRequest(new FailureModel("Opss não conseguimos salvar seu café.")));
        }
    }
}