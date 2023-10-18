using FastEndpoints;

using Bed.Src.Application.Models;
using Bed.Src.Presentation.Endpoints.Coffee;

namespace Bed.Src.Presentation.Summaries.Coffee
{
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
}