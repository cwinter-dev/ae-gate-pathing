using AEBestGatePath.API.Auth.Options;
using AEBestGatePath.API.Auth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AEBestGatePath.API.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this RouteGroupBuilder group)
    {
        group
            .MapDelete("",
                async (ITokenService tokenService, IUserService userService, HttpRequest request, CancellationToken cancellationToken) =>
                {
                    var authHeader = request.Headers.Authorization.FirstOrDefault();
                    var accessToken = authHeader?.Remove(0, "bearer".Length).Trim();

                    if (string.IsNullOrWhiteSpace(accessToken))
                    {
                        return Results.Unauthorized();
                    }

                    try
                    {
                        var userId = tokenService.GetUserId(accessToken);

                        await userService.DeleteAsync(userId, cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return Results.BadRequest();
                    }

                    return Results.NoContent();
                })
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status204NoContent)
            .RequireAuthorization();
        
        
    }
}