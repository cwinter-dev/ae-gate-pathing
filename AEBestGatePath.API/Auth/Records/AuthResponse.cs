namespace AEBestGatePath.API.Auth.Records;

public sealed record AuthResponse(
    string ExternalId,
    string Username,
    string Email,
    string? ProfilePicture
);
