using FastEndpoints;

public class UpdateSummary : Summary<UpdateEndpoint>
{
    public UpdateSummary()
    {
        Summary = "Edite um café.";
        Description = "Atualize um cfé do seu estoque";
        Response<CoffeeOutModel>(200, "Café atualizado com sucesso.");
        Response<FailuresModel>(400, "Falha ao atualizar os dados.");
    }
}