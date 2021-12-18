using DataPaginator.Example.WebApi.Data;
using DataPaginator.Example.WebApi.Helpers;
using DataPaginator.Example.WebApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure DI
builder.Services.AddScoped<IDogRepository, DogRepository>();

// Configure InMemory Database
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("my_dogs_database"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    DatabaseGenerator.Initializer(services);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
