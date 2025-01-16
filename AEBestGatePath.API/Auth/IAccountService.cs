namespace AEBestGatePath.API.Auth;

public interface IAccountService
{
    Task<TokenResponseModel> RegisterGoogleUser(RegisterGoogleUserModel googleUserModel);
}