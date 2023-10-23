using FastEndpoints;

using Bed.src.application.models;
using Bed.src.presentation.endpoints.coffee;

namespace Bed.src.presentation.summaries.coffee;

public class UpdateSummary : Summary<UpdateEndpoint>
{
    public UpdateSummary()
    {
        Summary = "Edite um café.";
        Description = "Atualize um café do seu estoque";
        Response<CoffeeOutModel>(200, "Café atualizado com sucesso.");
        Response<FailuresModel>(400, "Falha ao atualizar os dados.");
    }
}
