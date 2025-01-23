namespace AEBestGatePath.API.Auth.Records;

public sealed record SignInResponse(
    string AccessToken,
    RefreshToken RefreshToken
);