using LanguageExt;

using Bed.src.application.models;
using Bed.src.application.usecases;
using Bed.src.application.validators;

namespace Bed.src.presentation.endpoints;

public static class UseEndpoints
{
    public static void UseCoffeeEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder? coffee = app.MapGroup("/v1/coffee");

        coffee.MapGet("/", GetPaginate)
            .WithTags("Coffee")
            .WithName("Get paginate")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        coffee.MapGet("/{id}", GetById)
            .WithTags("Coffee")
            .WithName("Get by id")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

        coffee.MapPost("/", Create)
            .WithTags("Coffee")
            .WithName("Create")
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .AddEndpointFilter<FilterValidation<CoffeeInModel>>();

        coffee.MapPut("/{id}", Update)
            .WithTags("Coffee")
            .WithName("Update")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .AddEndpointFilter<FilterValidation<CoffeeInModel>>();

        coffee.MapDelete("/{id}", Delete)
            .WithTags("Coffee")
            .WithName("Delete")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest);
    }

    private async static Task<IResult> GetPaginate(
        int? page,
        int? limit,
        IGetPaginateUseCase useCase,
        CancellationToken cancellation
    )
    {
        Either<FailureOutModel, List<CoffeeOutModel>> response =
            await useCase.Execute(new Tuple<int, int>(page ?? 1, limit ?? 10), cancellation);

        return response.Match(
           Right: success => Results.Ok(success),
           Left: failure => Results.BadRequest(failure)
       );
    }

    private async static Task<IResult> GetById(
        Guid id,
        IGetByIdUseCase useCase,
        CancellationToken cancellation
    )
    {
        Either<FailureOutModel, CoffeeOutModel> response = await useCase.Execute(id, cancellation);

        return response.Match(
            Right: success => Results.Ok(success),
            Left: failure => Results.NotFound(failure)
        );
    }

    private async static Task<IResult> Create(
        CoffeeInModel data,
        ICreateUseCase useCase,
        CancellationToken cancellation
    )
    {
        Either<FailureOutModel, CoffeeOutModel> response = await useCase.Execute(data, cancellation);

        return response.Match(
            Left: failure => Results.BadRequest(failure),
            Right: success => Results.Created($"/coffe/{success.Id}", success)
        );
    }

    private async static Task<IResult> Update(
        Guid id,
        CoffeeInModel data,
        IUpdateUseCase useCase,
        CancellationToken cancellation
    )
    {
        Either<FailureOutModel, CoffeeOutModel> response = await useCase.Execute(
            new Tuple<Guid, CoffeeInModel>(id, data), cancellation
        );

        return response.Match(
            Right: success => Results.Ok(success),
            Left: failure => Results.BadRequest(failure)
        );
    }

    private async static Task<IResult> Delete(Guid id, IDeleteUseCase useCase, CancellationToken cancellation)
    {
        Either<FailureOutModel, bool> response = await useCase.Execute(id, cancellation);

        return response.Match(
            Left: failure => Results.BadRequest(failure),
            Right: success => success ? Results.NoContent() : Results.BadRequest("Um erro ocorreu ao tentar deletar o café.")
        );
    }
}