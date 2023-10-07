public static class CoffeeEndpoints
{
    public static void UseCoffeeEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder? coffee = app.MapGroup("/coffee");

        coffee.MapGet("/{id}", Get)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetCoffee")
            .WithTags("Coffee");

        coffee.MapGet("/", GetAll)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("GetCoffees")
            .WithTags("Coffee");

        coffee.MapPost("/", Create)
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("CreateCoffee")
            .WithTags("Coffee");

        coffee.MapPut("/{id}", Update)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("UpdateCoffee")
            .WithTags("Coffee");

        coffee.MapDelete("/{id}", Delete)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("DeleteCoffee")
            .WithTags("Coffee");
    }

    private async static Task<IResult> GetAll(IUseCase<Parameter> useCase) =>
        await useCase!.Execute(parameter: new Parameter());

    private async static Task<IResult> Get(Guid id, IUseCase<GetParameter> useCase) =>
        await useCase.Execute(parameter: new GetParameter(id));

    private async static Task<IResult> Create(Coffee data, IUseCase<CreateParameter> useCase) =>
        await useCase!.Execute(parameter: new CreateParameter(data));

    private async static Task<IResult> Update(Guid id, Coffee data, IUseCase<UpdateParameter> useCase) =>
        await useCase!.Execute(parameter: new UpdateParameter(id, data));

    private async static Task<IResult> Delete(Guid id, IUseCase<DeleteParameter> useCase) =>
        await useCase!.Execute(parameter: new DeleteParameter(id));
}