using FastEndpoints;

public class CreateSummary : Summary<CreateEndpoint>
{
    public CreateSummary()
    {
        Summary = "Crie uma novo café.";
        Description = "Atualize seu estoque criando um novo café.";
        Response<CoffeeOutModel>(201, "Café criado com sucesso.");
        Response<FailuresModel>(400, "Falha ao validarde os dados.");
    }
}