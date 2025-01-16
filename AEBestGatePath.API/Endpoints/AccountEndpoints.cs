using AEBestGatePath.API.Auth;

namespace AEBestGatePath.API.Endpoints;

public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/register-google-user",
            async (RegisterGoogleUserModel googleUserModel, IAccountService accountService) =>
            {
                var result = await accountService.RegisterGoogleUser(googleUserModel);
                return result;
            });
    }
}