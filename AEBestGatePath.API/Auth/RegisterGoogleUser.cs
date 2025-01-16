namespace AEBestGatePath.API.Auth;

public class RegisterGoogleUserModel(string name, string uid)
{
    public string Name { get; set; } = name;
    public string Uid { get; set; } = uid;
}