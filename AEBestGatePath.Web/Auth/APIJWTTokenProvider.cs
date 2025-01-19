using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Kiota.Abstractions.Authentication;

namespace AEBestGatePath.Web.Auth;

public class APIJWTTokenProvider : IAccessTokenProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public APIJWTTokenProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public string AccessToken { get; set; } = string.Empty;
    public Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object>? additionalAuthenticationContext = null,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult(AccessToken);
        //return Task.FromResult(((ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity)?.FindFirst("APIjwt")?.Value);
    }

    public AllowedHostsValidator AllowedHostsValidator { get; } = new ();
}