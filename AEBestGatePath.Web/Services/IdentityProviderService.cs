using Microsoft.AspNetCore.Components;

namespace AEBestGatePath.Web.Services;

public class IdentityProviderService(
    IHttpClientFactory httpClientFactory, 
    NavigationManager navigationManager, 
    BrowserStorageService browserStorage)
{
    public async Task AuthenticateWithGoogle()
    {
        var httpClient = httpClientFactory.CreateClient("auth");

        // Call our backend API to retrieve a URL for Google authentication.
        // Preserve the current URI in the state, so we can return the user back
        // to the same page after successful authentication
        var httpResponseMessage = await httpClient.GetAsync($"auth/redirect/google?state={navigationManager.Uri}");

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            // Remove any previous access tokens to our API
            await browserStorage.RemoveAccessToken();

            // Navigate the user to the Google authentication page
            var googleAuthenticationUrl = await httpResponseMessage.Content.ReadAsStringAsync();
            navigationManager.NavigateTo(googleAuthenticationUrl);
        }
    }
}