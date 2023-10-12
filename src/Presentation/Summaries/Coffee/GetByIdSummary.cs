using FastEndpoints;

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