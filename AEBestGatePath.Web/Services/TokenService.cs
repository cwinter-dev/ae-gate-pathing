using System.Net.Http.Json;

namespace AEBestGatePath.Web.Services;

public class TokenService(IHttpClientFactory httpClientFactory)
{
    public async Task<string?> RefreshAccessToken(string oldToken, CancellationToken cancellationToken = default)
    {
        using var client = httpClientFactory.CreateClient("auth");

        var tokenRefreshResponse = await client.PostAsJsonAsync("token/refresh", oldToken, cancellationToken);
        if (!tokenRefreshResponse.IsSuccessStatusCode) return null;
        var newAccessToken = await tokenRefreshResponse.Content.ReadAsStringAsync(cancellationToken);
        return newAccessToken;
    }
}