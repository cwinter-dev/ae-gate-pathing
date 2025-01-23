namespace AEBestGatePath.API.Auth;

public static class HeaderUtils
{
    public static bool TryGetAuthorizationToken(this IHeaderDictionary requestHeaders, out string? authorizationToken)
    {
        authorizationToken = null;

        string? authorizationHeaderValue = requestHeaders.Authorization;
        if (authorizationHeaderValue is null)
        {
            return false;
        }

        if (!authorizationHeaderValue.StartsWith("bearer", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        authorizationToken = authorizationHeaderValue.Remove(0, "bearer".Length).Trim();
        return true;
    }
}