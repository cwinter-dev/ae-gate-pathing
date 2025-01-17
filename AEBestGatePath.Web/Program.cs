using AEBestGatePath.API.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AEBestGatePath.Web;
using AEBestGatePath.Web.Auth;
using AEBestGatePath.Web.Shared.Date;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using IAccessTokenProvider = Microsoft.Kiota.Abstractions.Authentication.IAccessTokenProvider;

// using Microsoft.Kiota.Http.HttpClientLibrary.Middleware;
// using Microsoft.Kiota.Http.HttpClientLibrary.Middleware.Options;
var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazorContextMenu();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


// TODO: https://github.com/TDMR87/BlazorOAuth/tree/main
builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.Authority = "https://accounts.google.com/";
    options.ProviderOptions.ClientId = "704748717086-sr5n5p4qlalrm4nljbqhh7du06qj8i2d.apps.googleusercontent.com";
    // options.ProviderOptions.DefaultScopes.Add("openid");
    options.ProviderOptions.ResponseType = "id_token";
    // options.ProviderOptions.DefaultScopes.Add("https://www.googleapis.com/auth/userinfo.email");
    // options.ProviderOptions.DefaultScopes.Add("https://www.googleapis.com/auth/userinfo.profile");
    options.ProviderOptions.DefaultScopes.Add("openid");
    options.ProviderOptions.DefaultScopes.Add("profile");
    options.ProviderOptions.DefaultScopes.Add("email");
    // Configure your authentication provider options here.
    // For more information, see https://aka.ms/blazor-standalone-auth
    // builder.Configuration.Bind("Local", options.ProviderOptions);
})
.AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, RemoteUserAccount, CustomAccountFactory>();;

// Add the Kiota Client.
builder.Services.AddSingleton<IAccessTokenProvider, APIJWTTokenProvider>();
builder.Services.AddScoped<IAuthenticationProvider, BaseBearerTokenAuthenticationProvider>();
builder.Services.AddSingleton<APIJWTTokenProvider>();
builder.Services.AddScoped<IJsDateInterop, JsDateInterop>();

builder.Services
    .AddHttpClient<IRequestAdapter, HttpClientRequestAdapter>(client =>
    {
        client.BaseAddress = new Uri("http://localhost:50420");
    });
    //.AddHttpMessageHandler<CookieHandler>()

builder.Services.AddScoped<AEBestGatePathClient>();

await builder.Build().RunAsync();