using MovieStoreApi.Models;
using MovieStoreApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MovieStoreDatabaseSettings>(
    builder.Configuration.GetSection("MovieStoreDatabase"));

builder.Services.AddSingleton<MoviesService>();

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();