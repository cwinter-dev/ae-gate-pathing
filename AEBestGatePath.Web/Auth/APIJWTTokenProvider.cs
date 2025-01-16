using Microsoft.Kiota.Abstractions.Authentication;

namespace AEBestGatePath.Web.Auth;

public class APIJWTTokenProvider : IAccessTokenProvider
{
    public string AccessToken { get; set; } = string.Empty;
    public Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object>? additionalAuthenticationContext = null,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult(AccessToken);
    }

    public AllowedHostsValidator AllowedHostsValidator { get; } = new ();
}