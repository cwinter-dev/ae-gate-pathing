using AEBestGatePath.API.Auth.Options;
using AEBestGatePath.API.Auth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AEBestGatePath.API.Endpoints;

public static class TokenEndpoints
{
    public static void MapTokenEndpoints(this RouteGroupBuilder group)
    {
        group
            .MapPost("/refresh",
                async ([FromBody] string accessToken, ITokenService tokenService, IUserService userService, HttpRequest request, IOptions<RefreshTokenOptions> refreshTokenOptions, CancellationToken cancellationToken) =>
                {
                    if (!request.Cookies.TryGetValue(refreshTokenOptions.Value.CookieName, out var refreshToken))
                    {
                        return Results.BadRequest();
                    }

                    try
                    {
                        var userId = tokenService.GetUserId(accessToken);
                        var user = await userService.GetByIdAsync(userId, cancellationToken);
                        
                        if (user == null) throw new ApplicationException($"Unable to find user with ID '{userId}'.");

                        if (user.RefreshToken != refreshToken || user.RefreshTokenExpiresUtc <= DateTime.UtcNow)
                            throw new ApplicationException($"Unable to refresh access token for user with ID '{userId}'.");

                        var accessTokenResult = tokenService.GenerateAccessToken(user);

                        return Results.Text(accessTokenResult);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        return Results.BadRequest();
                    }
                })
            .Produces<string>()
            .Produces(StatusCodes.Status400BadRequest)
            .AllowAnonymous();
        
        
    }
}