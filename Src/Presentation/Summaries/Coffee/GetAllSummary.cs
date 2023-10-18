using FastEndpoints;

using Bed.Src.Application.Models;
using Bed.Src.Presentation.Endpoints.Coffee;

namespace Bed.Src.Presentation.Summaries.Coffee
{
    public class GetAllSummary : Summary<GetAllEndpoint>
    {
        public GetAllSummary()
        {
            Summary = "Liste todos os cafés.";
            Description = "Lista todos os cafés do estoque.";
            Response<List<CoffeeOutModel>>(200, "Cafés cadastrados.");
            Response<FailureModel>(400, "Falha ao listar os cafés.");
        }
    }
}