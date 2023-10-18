using FastEndpoints;

using Bed.Src.Application.Models;
using Bed.Src.Application.UseCases;

namespace Bed.Src.Presentation.Endpoints.Coffee
{
    public class DeleteEndpoint : EndpointWithoutRequest<CoffeeOutModel>
    {
        private readonly IDeleteUseCase _useCase;

        public DeleteEndpoint(IDeleteUseCase useCase)
        {
            _useCase = useCase;
        }

        public override void Configure()
        {
            Tags("Coffee");
            AllowAnonymous();
            Verbs(Http.DELETE);
            Delete("/coffee/{Guid}");
            Routes("/coffee/{Guid}");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            Guid id = Route<Guid>("Guid");
            bool response = await _useCase.Execute(id);

            if (response) await SendResultAsync(Results.NoContent());
            else await SendResultAsync(Results.BadRequest(new FailureModel("Opss não conseguimos deletar seu café.")));
        }
    }
}