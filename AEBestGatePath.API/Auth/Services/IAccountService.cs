using AEBestGatePath.API.Auth.Records;

namespace AEBestGatePath.API.Auth.Services;

public interface IAccountService
{
    Task<AuthResponse> AuthenticateWithGoogleAsync(string authorizationCode, CancellationToken cancellationToken = default);
    Task<SignInResponse> SignInAsync(AuthResponse authResponse, CancellationToken cancellationToken = default);
}