using Microsoft.EntityFrameworkCore;
using PetApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PetContext") ?? throw new InvalidOperationException("Connection string 'PetContext' not found.");

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<PetContext>(opt =>
    opt.UseInMemoryDatabase("PetList"));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();