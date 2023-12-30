using FluentValidation;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

using Bed.src.domain.repositories;
using Bed.src.application.usecases;
using Bed.src.presentation.endpoints;
using Bed.src.infrastructure.database;
using Bed.src.infrastructure.repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(collection =>
{
    collection.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Coffee Shop API Sample",
        Description = "Developed by Gabriel Ramos - @bed72",
        Contact = new OpenApiContact { Name = "Gabriel Ramos", Email = "developer.bed@gmail.com" },
        License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
    });
});

string connection = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ConnectionDatabase>(options => options.UseNpgsql(connection));
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});


builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddScoped<IRepository, CoffeeEntityRepository>();

builder.Services.AddScoped<ICreateUseCase, CreateUseCase>();
builder.Services.AddScoped<IGetByIdUseCase, GetByIdUseCase>();
builder.Services.AddScoped<IGetPaginateUseCase, GetPaginateUseCase>();
builder.Services.AddScoped<IUpdateUseCase, UpdateUseCase>();
builder.Services.AddScoped<IDeleteUseCase, DeleteUseCase>();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCoffeeEndpoints();

app.Run();