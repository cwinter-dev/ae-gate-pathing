using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace AEBestGatePath.Web.Services;

public class UserAuthenticationStateProvider(BrowserStorageService storageService, TokenService tokenService) : AuthenticationStateProvider
{
    private readonly ClaimsPrincipal _anonymousUser = new(new ClaimsIdentity());
    public CurrentUser CurrentUser { get; private set; } = new();

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var claimsPrincipal = await GetClaimsPrincipal();
        UpdateCurrentUser(claimsPrincipal);
        return new(claimsPrincipal);
    }

    private async Task<ClaimsPrincipal> GetClaimsPrincipal()
    {
        var tokenFromStorage = await storageService.GetAccessToken();
        if (string.IsNullOrWhiteSpace(tokenFromStorage))
        {
            CurrentUser = new();
            return _anonymousUser;
        }

        var accessToken = new JwtSecurityTokenHandler().ReadJwtToken(tokenFromStorage);
        if (accessToken.ValidTo < DateTime.UtcNow)
        {
            var refreshedToken = await tokenService.RefreshAccessToken(tokenFromStorage);
            if (refreshedToken is null)
            {
                CurrentUser = new();
                return _anonymousUser;
            }

            await storageService.SaveAccessToken(refreshedToken);
        }

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(accessToken.Claims, "BlazorOAuth"));
        UpdateCurrentUser(claimsPrincipal);
        return claimsPrincipal;
    }

    public async Task NotifyUserLoggedin()
    {
        var principal = await GetClaimsPrincipal();
        var authState = Task.FromResult(new AuthenticationState(principal));
        NotifyAuthenticationStateChanged(authState);
    }

    public async Task NotifyUserLoggedOut()
    {
        await storageService.RemoveAccessToken();
        var authState = Task.FromResult(new AuthenticationState(_anonymousUser));
        NotifyAuthenticationStateChanged(authState);
    }

    private void UpdateCurrentUser(ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal.Identity?.IsAuthenticated == true)
        {
            CurrentUser = new()
            {
                IsAuthenticated = true,
                Id = Guid.Parse(claimsPrincipal.FindFirst(c => c.Type == "id")?.Value!),
                Username = claimsPrincipal.FindFirst(c => c.Type == "unique_name")?.Value,
                Email = claimsPrincipal.FindFirst(c => c.Type == "email")?.Value,
                ProfilePicture = claimsPrincipal.FindFirst(c => c.Type == "profilepicture")?.Value,
                SignInCount = int.Parse(claimsPrincipal.FindFirst(c => c.Type == "signincount")?.Value!),
                Roles = claimsPrincipal.Claims.Where(c => c.Type.Contains("role")).Select(c => c.Value).ToArray()
            };
        }
        else
        {
            CurrentUser = new();
        }
    }
}

public class CurrentUser
{
    public Guid? Id { get; init; } = null;
    public bool IsAuthenticated { get; init; }
    public string? Username { get; init; }
    public string? Email { get; init; }
    public string? ProfilePicture { get; init; }
    public int SignInCount { get; set; }
    public string[] Roles { get; init; } = [];
    public string GetSignInCountOrdinal()
    {
        if (SignInCount <= 0) return string.Empty;

        return (SignInCount % 100) switch
        {
            11 or 12 or 13 => SignInCount + "th",
            _ => (SignInCount % 10) switch
            {
                1 => SignInCount + "st",
                2 => SignInCount + "nd",
                3 => SignInCount + "rd",
                _ => SignInCount + "th",
            },
        };
    }
}