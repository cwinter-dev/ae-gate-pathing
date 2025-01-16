using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AEBestGatePath.Data.Auth.Context;
using AEBestGatePath.Data.Auth.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AEBestGatePath.API.Auth;

public class AccountService(
    AuthContext authContext,
    IOptions<TokenSettings> tokenSettings)
    : IAccountService
{
    
    private readonly AuthContext _authContext = authContext;
 
    private readonly TokenSettings _tokenSettings = tokenSettings.Value;
    
    private async Task<User> CreateNewUser(
        RegisterGoogleUserModel googleUserModel,
        List<UserRoles> userRoles)
    {
        var user = new User
        {
            GoogleUid = googleUserModel.Uid,
            Name = googleUserModel.Name,
        };
        _authContext.User.Add(user);
        await _authContext.SaveChangesAsync();
 
        var defaultRole = new UserRoles
        {
            Name = "admin",
            UserId = user.UserId
        };
 
        userRoles.Add(defaultRole);
        await _authContext.SaveChangesAsync();
        return user;
    }
    private string GetJWTAuthKey(List<UserRoles> roles)
    {
        var securtityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Key));
 
        var credentials = new SigningCredentials(securtityKey, SecurityAlgorithms.HmacSha256);
 
        var claims = new List<Claim>();
        if ((roles?.Count ?? 0) > 0)
        {
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
        }
 
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _tokenSettings.Issuer,
            audience: _tokenSettings.Audience,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials,
            claims: claims
        );
 
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
    public async Task<TokenResponseModel> RegisterGoogleUser(RegisterGoogleUserModel googleUserModel)
    {
        var user = _authContext.User.FirstOrDefault(x => x.GoogleUid == googleUserModel.Uid);
        var userRoles = new List<UserRoles>();
        user ??= await CreateNewUser(googleUserModel, userRoles);
 
        if (userRoles.Count == 0)
        {
            userRoles = _authContext.UserRoles.Where(x => x.UserId == user.UserId).ToList();
        }
 
        return new TokenResponseModel(GetJWTAuthKey(userRoles));
    }
}