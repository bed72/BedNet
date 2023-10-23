using FastEndpoints;

using Bed.src.application.models;
using Bed.src.presentation.endpoints.coffee;

namespace Bed.src.presentation.summaries.coffee;

public class CreateSummary : Summary<CreateEndpoint>
{
    public CreateSummary()
    {
        Summary = "Crie uma novo café.";
        Description = "Crie uma novo café para seu estoque.";
        Response<CoffeeOutModel>(201, "Café criado com sucesso.");
        Response<FailuresModel>(400, "Falha ao validar os dados.");
    }
}
