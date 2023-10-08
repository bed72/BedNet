using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDbContext<Database>(opt => opt.UseInMemoryDatabase("coffees"));

builder.Services.AddScoped<IRepository, CoffeeEntityRepository>();

builder.Services.AddScoped<IGetAllUseCase, GetAllUseCase>();
builder.Services.AddScoped<IGetByIdUseCase, GetByIdUseCase>();
builder.Services.AddScoped<ICreateUseCase, CreateUseCase>();
builder.Services.AddScoped<IUpdateUseCase, UpdateUseCase>();
builder.Services.AddScoped<IDeleteUseCase, DeleteUseCase>();

builder.Services.AddScoped<IMapper<CoffeeInModel, CoffeeEntity>, ToEntityMapper>();
builder.Services.AddScoped<IMapper<CoffeeEntity, CoffeeOutModel>, ToModelMapper>();

WebApplication? app = builder.Build();
app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCoffeeEntityEndpoints();

app.Run();