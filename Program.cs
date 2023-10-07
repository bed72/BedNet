using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(collection =>
{
    collection.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Coffee API Sample",
        Description = "Developed by Gabriel Ramos - Owner @bed72",
        Contact = new OpenApiContact { Name = "Gabriel Ramos", Email = "developer.bed@gmail.com" },
        License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
    });
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDbContext<Database>(opt => opt.UseInMemoryDatabase("Coffees"));

builder.Services.AddScoped<ICoffeeRepository, CoffeeRepository>();

builder.Services.AddScoped<IUseCase<Parameter>, GetCoffeesUseCase>();
builder.Services.AddScoped<IUseCase<GetParameter>, GetCoffeeUseCase>();
builder.Services.AddScoped<IUseCase<CreateParameter>, CreateCoffeeUseCase>();
builder.Services.AddScoped<IUseCase<UpdateParameter>, UpdateCoffeeUseCase>();
builder.Services.AddScoped<IUseCase<DeleteParameter>, DeleteCoffeeUseCase>();

WebApplication? app = builder.Build();
app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCoffeeEndpoints();

app.Run();