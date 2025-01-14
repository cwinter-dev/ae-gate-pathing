using AEBestGatePath.API.Endpoints;
using AEBestGatePath.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AstroEmpiresContext>(opt => opt.UseNpgsql(
    builder.Configuration.GetConnectionString("AstroEmpiresContext"),
    o => o.SetPostgresVersion(16, 0)));


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("Running Development");
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGroup("/gates")
    .MapGateEndpoints();
app.MapGroup("/route")
    .MapRouteEndpoints();
app.MapGroup("/guilds")
    .MapGuildEndpoints();

app.Run();
