using FastEndpoints;

using Bed.src.application.models;
using Bed.src.presentation.endpoints.coffee;

namespace Bed.src.presentation.summaries.coffee;

public class DeleteSummary : Summary<DeleteEndpoint>
{
    public DeleteSummary()
    {
        Summary = "Apague o café que procura.";
        Description = "Apague o café a partir do seu identificador.";
        Response<CoffeeOutModel>(204, "Café deletado.");
        Response<FailureModel>(400, "Falha ao deletar o café.");
    }
}
