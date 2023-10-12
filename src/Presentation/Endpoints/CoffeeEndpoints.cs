using Microsoft.AspNetCore.Http.HttpResults;

// public static class CoffeeEntityEndpoints
// {
//     public static void UseCoffeeEndpoints(this IEndpointRouteBuilder app)
//     {
//         RouteGroupBuilder? coffee = app.MapGroup("/coffee");

//         coffee.MapGet("/", GetAll)
//             .WithTags("Coffee")
//             .WithName("Get all")
//             .Produces(StatusCodes.Status200OK)
//             .Produces(StatusCodes.Status400BadRequest);

//         coffee.MapGet("/{id}", GetById)
//             .WithTags("Coffee")
//             .WithName("Get by id")
//             .Produces(StatusCodes.Status200OK)
//             .Produces(StatusCodes.Status404NotFound);

//         coffee.MapPost("/", Create)
//             .WithTags("Coffee")
//             .WithName("Create")
//             .Produces(StatusCodes.Status201Created)
//             .Produces(StatusCodes.Status400BadRequest);

//         coffee.MapPut("/{id}", Update)
//             .WithTags("Coffee")
//             .WithName("Update")
//             .Produces(StatusCodes.Status204NoContent)
//             .Produces(StatusCodes.Status400BadRequest);

//         coffee.MapDelete("/{id}", Delete)
//             .WithTags("Coffee")
//             .WithName("Delete")
//             .Produces(StatusCodes.Status204NoContent)
//             .Produces(StatusCodes.Status400BadRequest);
//     }

//     private async static Task<IResult> GetAll(IGetAllUseCase useCase) =>
//         await useCase.Execute(null);

//     private async static Task<IResult> GetById(Guid id, IGetByIdUseCase useCase) =>
//         await useCase.Execute(id);

//     private async static Task<IResult> Create(CoffeeInModel data, ICreateUseCase useCase) =>
//         await useCase.Execute(data);

//     private async static Task<IResult> Update(Guid id, CoffeeInModel data, IUpdateUseCase useCase) =>
//         await useCase.Execute(new Tuple<Guid, CoffeeInModel>(id, data));

//     private async static Task<IResult> Delete(Guid id, IDeleteUseCase useCase) =>
//         await useCase.Execute(id);
// }