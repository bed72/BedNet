using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.SwaggerDocument();
builder.Services.AddFastEndpoints();
builder.Services.AddDbContext<Database>(opt => opt.UseInMemoryDatabase("coffees"));

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