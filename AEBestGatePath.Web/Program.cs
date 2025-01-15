using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AEBestGatePath.Web;
using AEBestGatePath.Web.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

// using Microsoft.Kiota.Http.HttpClientLibrary.Middleware;
// using Microsoft.Kiota.Http.HttpClientLibrary.Middleware.Options;
var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.Authority = "https://accounts.google.com/";
    options.ProviderOptions.ClientId = "704748717086-sr5n5p4qlalrm4nljbqhh7du06qj8i2d.apps.googleusercontent.com";
    // options.ProviderOptions.DefaultScopes.Add("openid");
    // options.ProviderOptions.DefaultScopes.Add("https://www.googleapis.com/auth/userinfo.email");
    // options.ProviderOptions.DefaultScopes.Add("https://www.googleapis.com/auth/userinfo.profile");
    options.ProviderOptions.ResponseType = "id_token";
    options.ProviderOptions.DefaultScopes.Add("openid");
    options.ProviderOptions.DefaultScopes.Add("profile");
    // Configure your authentication provider options here.
    // For more information, see https://aka.ms/blazor-standalone-auth
    // builder.Configuration.Bind("Local", options.ProviderOptions);
});

// Add the Kiota Client.
builder.Services.AddScoped<IAuthenticationProvider, AnonymousAuthenticationProvider>();

builder.Services
    .AddHttpClient<IRequestAdapter, HttpClientRequestAdapter>(client => client.BaseAddress = new Uri("http://localhost:50420"))
    //.AddHttpMessageHandler<CookieHandler>()
    ;

builder.Services.AddScoped<AEBestGatePathClient>();

await builder.Build().RunAsync();

public class CookieHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        return await base.SendAsync(request, cancellationToken);
    }
}