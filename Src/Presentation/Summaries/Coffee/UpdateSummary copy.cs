using FastEndpoints;

using Bed.Src.Application.Models;
using Bed.Src.Presentation.Endpoints.Coffee;

namespace Bed.Src.Presentation.Summaries.Coffee
{
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
}