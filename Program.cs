using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

using Bed.src.domain.repositories;
using Bed.src.application.usecases;
using Bed.src.infrastructure.database;
using Bed.src.infrastructure.repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.SwaggerDocument();
builder.Services.AddFastEndpoints();

string connection = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ConnectionDatabase>(options => options.UseNpgsql(connection));

builder.Services.AddScoped<IRepository, CoffeeEntityRepository>();

builder.Services.AddScoped<IGetAllUseCase, GetAllUseCase>();
builder.Services.AddScoped<IGetByIdUseCase, GetByIdUseCase>();
builder.Services.AddScoped<ICreateUseCase, CreateUseCase>();
builder.Services.AddScoped<IUpdateUseCase, UpdateUseCase>();
builder.Services.AddScoped<IDeleteUseCase, DeleteUseCase>();

WebApplication app = builder.Build();

app.UseFastEndpoints(fast =>
{
    fast.Endpoints.RoutePrefix = "v1";
    fast.Errors.StatusCode = 422;
    fast.Errors.ResponseBuilder = (failures, _, __) =>
        new HttpValidationProblemDetails(
            failures
                .GroupBy(failure => failure.PropertyName)
                .ToDictionary(
                    keySelector: e => e.Key.ToLower(),
                    elementSelector: e => e.Select(m => m.ErrorMessage).ToArray()
                )
        )
        {
            Title = "Parâmetros inválidos.",
        };
})
.UseSwaggerGen();

app.Run();