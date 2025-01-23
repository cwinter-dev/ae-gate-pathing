namespace AEBestGatePath.API.Auth.Records;

public sealed record RefreshToken(
    string Value,
    DateTime ExpiresUtc
);
