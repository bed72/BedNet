using FastEndpoints;

using Bed.Src.Application.Models;
using Bed.Src.Presentation.Endpoints.Coffee;

namespace Bed.Src.Presentation.Summaries.Coffee
{
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
}