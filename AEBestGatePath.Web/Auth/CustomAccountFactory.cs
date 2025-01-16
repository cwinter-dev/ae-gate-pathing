using System.Security.Claims;
using AEBestGatePath.API.Client;
using AEBestGatePath.API.Client.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

namespace AEBestGatePath.Web.Auth
{
    public class CustomAccountFactory
    : AccountClaimsPrincipalFactory<RemoteUserAccount>
    {
        private readonly AEBestGatePathClient _appAuthClient;
        public CustomAccountFactory(IAccessTokenProviderAccessor accessor,
            AEBestGatePathClient appAuthClient
            ) : base(accessor)
        {
            _appAuthClient = appAuthClient;
        }
 
        public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
            RemoteUserAccount account, RemoteAuthenticationUserOptions options)
        {
            var initialUser = await base.CreateUserAsync(account, options);
            try
            {
                if (initialUser.Identity?.IsAuthenticated == true)
                {
                    Console.WriteLine(string.Join(" - ", initialUser.Claims.Select(c => $"{c.Type}: {c.Value}")));
                    var googleUser = new RegisterGoogleUserModel
                    {
                        Uid = initialUser.Claims.Where(x => x.Type == "sub").Select(x => x.Value).FirstOrDefault(),
                        Name = initialUser.Claims.Where(x => x.Type == "name").Select(x => x.Value).FirstOrDefault(),
                    };
 
                    var response = await _appAuthClient.Accounts.RegisterGoogleUser.PostAsync(googleUser);
                    if (response is { JwtToken: not null })
                    {
                        ((ClaimsIdentity)initialUser.Identity).AddClaim(
                            new Claim("APIjwt", response.JwtToken)
                        );
                    }

                }
            }
            catch
            {
                initialUser = new ClaimsPrincipal(new ClaimsIdentity());
            }
 
            return initialUser;
        }
    }
}