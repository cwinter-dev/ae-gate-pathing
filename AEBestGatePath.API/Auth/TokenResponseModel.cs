namespace AEBestGatePath.API.Auth;

public class TokenResponseModel(string jwtToken)
{
    public string JwtToken { get; set; } = jwtToken;
}