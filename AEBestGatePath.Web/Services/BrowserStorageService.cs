using Microsoft.JSInterop;

namespace AEBestGatePath.Web.Services;

public class BrowserStorageService(IJSRuntime javascript)
{
    const string TokenName = "AETools.AccessToken";

    public async Task SaveAccessToken(string accessToken)
        => await javascript.InvokeVoidAsync("localStorage.setItem", TokenName, accessToken);
    public async Task<string> GetAccessToken()
        => await javascript.InvokeAsync<string>("localStorage.getItem", TokenName);
    public async Task RemoveAccessToken()
        => await javascript.InvokeAsync<string>("localStorage.removeItem", TokenName);
}
