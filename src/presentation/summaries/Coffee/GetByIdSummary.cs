using FastEndpoints;

using Bed.src.application.models;
using Bed.src.presentation.endpoints.coffee;

namespace Bed.src.presentation.summaries.coffee;

public class GetByIdSummary : Summary<GetByIdEndpoint>
{
    public GetByIdSummary()
    {
        Summary = "Encontre o café que procura.";
        Description = "Entre o café a partir do seu identificador.";
        Response<CoffeeOutModel>(200, "Café pesquisado.");
        Response<FailureModel>(400, "Falha ao encontrar o café.");
    }
}
