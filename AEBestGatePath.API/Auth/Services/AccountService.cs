using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AEBestGatePath.API.Auth.Options;
using AEBestGatePath.API.Auth.Records;
using AEBestGatePath.Data.Auth.Context;
using AEBestGatePath.Data.Auth.Models;
using Google.Apis.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AEBestGatePath.API.Auth.Services;

public class AccountService(
    IHttpClientFactory httpClientFactory,
    IOptions<AuthenticationOptions> options,
    IUserService userService,
    ITokenService tokenService)
    : IAccountService
{
    public async Task<AuthResponse> AuthenticateWithGoogleAsync(string authorizationCode,
        CancellationToken cancellationToken)
    {
        var config = options.Value.GoogleOptions!;

        var idTokenRequestContent = new FormUrlEncodedContent
        ([
            new KeyValuePair<string, string>("code", authorizationCode),
            new KeyValuePair<string, string>("client_id", config.ClientId),
            new KeyValuePair<string, string>("client_secret", config.ClientSecret),
            new KeyValuePair<string, string>("redirect_uri", config.RedirectUri),
            new KeyValuePair<string, string>("grant_type", "authorization_code")
        ]);

        // Exchange the Google authorization code for access token
        var authorizationCodeExchangeRequest = await httpClientFactory.CreateClient("auth").PostAsync(
            config.AuthorizationCodeEndpoint, idTokenRequestContent, cancellationToken);

        if (!authorizationCodeExchangeRequest.IsSuccessStatusCode)
        {
            var responseMessage = await authorizationCodeExchangeRequest.Content.ReadAsStringAsync(cancellationToken);
            throw new ApplicationException($"Authorization code exchange failed. {responseMessage}");
        }

        var idTokenContent =
            await authorizationCodeExchangeRequest.Content.ReadFromJsonAsync<GoogleToken>(cancellationToken);
        if (idTokenContent?.id_token is null)
        {
            throw new ApplicationException("id_token not found in the response from the identity provider");
        }

        try
        {
            var validatedUser = await GoogleJsonWebSignature.ValidateAsync
            (
                validationSettings: new() { Audience = [config.ClientId] },
                jwt: idTokenContent?.id_token
            );

            return new AuthResponse
            (
                ProfilePicture: validatedUser.Picture,
                ExternalId: validatedUser.Subject,
                Username: validatedUser.Name,
                Email: validatedUser.Email
            );
        }
        catch (InvalidJwtException e)
        {
            throw new ApplicationException($"The id_token did not pass validation. {e.Message}", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Encountered an error during id_token validation. {e.Message}", e);
        }
    }

    public async Task<SignInResponse> SignInAsync(AuthResponse authResponse,
        CancellationToken cancellationToken = default)
    {
        User appUser;

        var existingUser = await userService.GetByExternalIdAsync(authResponse.ExternalId, cancellationToken);
        if (existingUser != null)
        {
            appUser = existingUser;

            if (UserInfoChanged(currentInfo: appUser, newInfo: authResponse))
            {
                appUser.ProfilePicture = authResponse.ProfilePicture;
                appUser.Username = authResponse.Username;
                appUser.Email = authResponse.Email;
                await userService.UpdateAsync(appUser, CancellationToken.None);
            }
        }
        else
        {
            var createUser = await userService.CreateAsync(new()
            {
                ProfilePicture = authResponse.ProfilePicture,
                ExternalId = authResponse.ExternalId,
                Username = authResponse.Username,
                Email = authResponse.Email,
            }, CancellationToken.None);

            appUser = createUser;
        }

        var accessTokenResult = tokenService.GenerateAccessToken(appUser);

        var refreshTokenResult = tokenService.GenerateRefreshToken(appUser);

        appUser.RefreshToken = refreshTokenResult.Value;
        appUser.RefreshTokenExpiresUtc = refreshTokenResult.ExpiresUtc;
        appUser.SignInCount++;

        await userService.UpdateAsync(appUser, CancellationToken.None);
        return new SignInResponse(accessTokenResult, refreshTokenResult);
    }

    private static bool UserInfoChanged(User currentInfo, AuthResponse newInfo) =>
        currentInfo.Username != newInfo.Username ||
        currentInfo.Email != newInfo.Email ||
        currentInfo.ProfilePicture != newInfo.ProfilePicture;
}