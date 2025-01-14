using AEBestGatePath.API.Endpoints;
using AEBestGatePath.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

const string allowSpecificOrigins = "AllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:7282", "http://localhost:5206")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<AstroEmpiresContext>(opt => opt.UseNpgsql(
    builder.Configuration.GetConnectionString("AstroEmpiresContext"),
    o => o.SetPostgresVersion(16, 0)));


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors(allowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("Running Development");
    app.MapOpenApi();
}
else
{
    app.UseHttpsRedirection();
}

app.MapGroup("/gates")
    .MapGateEndpoints();
app.MapGroup("/route")
    .MapRouteEndpoints();
app.MapGroup("/guilds")
    .MapGuildEndpoints();

app.Run();
