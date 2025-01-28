using AEBestGatePath.API.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AEBestGatePath.Web;
using AEBestGatePath.Web.Services;
using AEBestGatePath.Web.Services.Http;
using AEBestGatePath.Web.Shared.Date;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IdentityProviderService>();
builder.Services.AddScoped<BrowserStorageService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<UserAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<UserAuthenticationStateProvider>());
builder.Services.AddTransient<CookieDelegatingHandler>();
builder.Services.AddTransient<TokenDelegatingHandler>();

builder.Services.AddHttpClient("auth", (serviceProvider, httpClient) =>
    {
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        httpClient.BaseAddress = new (configuration["ApiBaseAddress"]!);
    }).AddHttpMessageHandler<CookieDelegatingHandler>()
    .AddHttpMessageHandler<TokenDelegatingHandler>();



builder.Services.AddScoped<IAuthenticationProvider, AnonymousAuthenticationProvider>();
builder.Services
    .AddHttpClient<IRequestAdapter, HttpClientRequestAdapter>("kiota", (serviceProvider, httpClient) =>
    {
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        httpClient.BaseAddress = new (configuration["ApiBaseAddress"]!);
    }).AddHttpMessageHandler<CookieDelegatingHandler>()
    .AddHttpMessageHandler<TokenDelegatingHandler>();


builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorizationCore(x =>
{
    x.AddPolicy("admin", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("Role", "admin");
    });
});


builder.Services.AddScoped<AEBestGatePathClient>();
builder.Services.AddScoped<IJsDateInterop, JsDateInterop>();


builder.Services.AddBlazorContextMenu();
builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();