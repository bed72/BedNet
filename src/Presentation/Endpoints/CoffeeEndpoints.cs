public static class CoffeeEntityEndpoints
{
    public static void UseCoffeeEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder? coffee = app.MapGroup("/coffee");

        coffee.MapGet("/", GetAll)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("Get all")
            .WithTags("Coffee");

        coffee.MapGet("/{id}", GetById)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("Get by id")
            .WithTags("Coffee");

        coffee.MapPost("/", Create)
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("Create")
            .WithTags("Coffee");

        coffee.MapPut("/{id}", Update)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("Update")
            .WithTags("Coffee");

        coffee.MapDelete("/{id}", Delete)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("Delete")
            .WithTags("Coffee");
    }

    private async static Task<IResult> GetAll(IGetAllUseCase useCase) =>
        await useCase.Execute(null);

    private async static Task<IResult> GetById(Guid id, IGetByIdUseCase useCase) =>
        await useCase.Execute(id);

    private async static Task<IResult> Create(CoffeeInModel data, ICreateUseCase useCase) =>
        await useCase.Execute(data);

    private async static Task<IResult> Update(Guid id, CoffeeInModel data, IUpdateUseCase useCase) =>
        await useCase.Execute(new Tuple<Guid, CoffeeInModel>(id, data));

    private async static Task<IResult> Delete(Guid id, IDeleteUseCase useCase) =>
        await useCase.Execute(id);
}