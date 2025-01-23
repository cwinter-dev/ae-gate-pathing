using AEBestGatePath.API.Auth;
using AEBestGatePath.API.Auth.Options;
using AEBestGatePath.API.Auth.Records;
using AEBestGatePath.API.Auth.Services;
using Microsoft.Extensions.Options;

namespace AEBestGatePath.API.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this RouteGroupBuilder group)
    {
        group
            .MapGet("/signin/google",
                async (IAccountService accountService, HttpRequest request, HttpContext context, IOptions<RefreshTokenOptions> refreshTokenOptions) =>
                {
                    if (!request.Headers.TryGetAuthorizationToken(out var authorizationToken))
                        return Results.Unauthorized();
                    
                    try
                    {
                        var authenticationResult = await accountService.AuthenticateWithGoogleAsync(authorizationToken!);

                        var (accessToken, refreshToken) = await accountService.SignInAsync(authenticationResult);
                            
                        var config = refreshTokenOptions.Value;

                        context.Response.Cookies.Append(config.CookieName, refreshToken.Value, new()
                        {
                            Secure = true,
                            HttpOnly = true,
                            Path = "/token/refresh",
                            SameSite = SameSiteMode.None,
                            Expires = refreshToken.ExpiresUtc
                        });

                        return Results.Text(accessToken);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return Results.Unauthorized();
                    }
                })
            .Produces<string>()
            .Produces(StatusCodes.Status401Unauthorized)
            .AllowAnonymous();
        
        group.MapGet("/redirect/google", (string state, IOptions<AuthenticationOptions> authenticationOptions) =>
            {
                var config = authenticationOptions.Value.GoogleOptions!;

                var googleAuthUrl =
                    $"{config.AuthenticationEndpoint}?" +
                    $"response_type={config.ResponseType}&" +
                    $"client_id={config.ClientId}&" +
                    $"redirect_uri={config.RedirectUri}&" +
                    $"scope={config.Scope}&" +
                    $"state={state}&" +
                    $"nonce={Guid.NewGuid()}";

                return googleAuthUrl;
            }).Produces<string>()
            .AllowAnonymous();
        
        
    }
}