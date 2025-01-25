using System.Text;
using System.Text.Json.Serialization;
using AEBestGatePath.API.Auth.Options;
using AEBestGatePath.API.Auth.Services;
using AEBestGatePath.API.Endpoints;
using AEBestGatePath.Data.AstroEmpires.Context;
using AEBestGatePath.Data.Auth.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AutoRestExtensions;
using Google.Cloud.SecretManager.V1;

//SecretManagerServiceClient client = SecretManagerServiceClient.Create();
var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// builder.Services.AddSecretManagerServiceClient((builder) =>
// {
//     builder.
// })
builder.Services.AddHttpClient();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<AuthContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("AuthContext"),
        o => o.SetPostgresVersion(16, 6));
});

builder.Services.AddDbContext<AstroEmpiresContext>(opt => opt.UseNpgsql(
    builder.Configuration.GetConnectionString("AstroEmpiresContext"),
    o => o.SetPostgresVersion(16, 6)));
builder.Services.Configure<AuthenticationOptions>(builder.Configuration.GetSection("Authentication"));
builder.Services.Configure<AuthorizationOptions>(builder.Configuration.GetSection("Authorization"));
builder.Services.Configure<RefreshTokenOptions>(builder.Configuration.GetSection("Authorization:RefreshTokenOptions"));

const string allowSpecificOrigins = "AllowSpecificOrigins";
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(allowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:7282", "http://localhost:5206", "https://probable-byway-237515.web.app", "https://probable-byway-237515.firebase.app")
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        var jwtOptions = builder.Configuration.GetSection("Authorization:JwtOptions").Get<JwtOptions>()!;
        options.TokenValidationParameters = new()
        {
            ValidIssuer = jwtOptions.ValidIssuer,
            ValidAudience = jwtOptions.ValidAudience,
            ValidateIssuer = jwtOptions.ValidateIssuer,
            ValidateLifetime = jwtOptions.ValidateLifetime,
            ValidateAudience = jwtOptions.ValidateAudience,
            ValidateIssuerSigningKey = jwtOptions.ValidateSigningKey,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.IssuerSigningKey!))
        };
    });


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", //Name the security scheme
        new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme.",
            Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
            Scheme = "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
        });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    { 
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Id = "Bearer", //The name of the previously defined security scheme.
                    Type = ReferenceType.SecurityScheme
                }
            },new List<string>()
        }
    });
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AEBestGatePath.API", Version = "v1" });
    c.SchemaFilter<EnumTypeSchemaFilter>(false);
    //c.DescribeAllEnumsAsStrings();
    // Set the comments path for the Swagger JSON and UI.
    // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // c.IncludeXmlComments(xmlPath);
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("admin", policy =>
        policy
            .RequireRole("admin"));
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors(allowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("Running Development");
    app.MapOpenApi();
    
    app.UseSwagger(c => c.RouteTemplate = "/swagger/{documentName}/swagger.json");
    app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/v1/swagger.json", "AEBestGatePath.API v1"));
}
// else
// {
//     app.UseHttpsRedirection();
// }

app.MapGroup("/gates")
    .MapGateEndpoints();
app.MapGroup("/players")
    .MapPlayerEndpoints();
app.MapGroup("/route")
    .MapRouteEndpoints();
app.MapGroup("/guilds")
    .MapGuildEndpoints();
app.MapGroup("/auth")
    .MapAuthEndpoints();
app.MapGroup("/token")
    .MapTokenEndpoints();
app.MapGroup("/user")
    .MapUserEndpoints();



app.Run();
