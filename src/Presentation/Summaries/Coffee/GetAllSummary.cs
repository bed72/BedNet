using FastEndpoints;

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