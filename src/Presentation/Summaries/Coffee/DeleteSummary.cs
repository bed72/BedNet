using FastEndpoints;

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