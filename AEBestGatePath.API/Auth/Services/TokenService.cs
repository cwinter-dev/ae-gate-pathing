using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AEBestGatePath.API.Auth.Options;
using AEBestGatePath.API.Auth.Records;
using AEBestGatePath.Data.Auth.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AEBestGatePath.API.Auth.Services;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    RefreshToken GenerateRefreshToken(User user);
    Guid GetUserId(string accessToken);
}

internal class TokenService(IOptions<AuthorizationOptions> options) : ITokenService
{
    public string GenerateAccessToken(User user)
    {
        var config = options.Value.JwtOptions!;

        var sub = new List<Claim>
        {
            new("id", user.Id.ToString()),
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Email, user.Email ?? string.Empty),
            new("profilepicture", user.ProfilePicture ?? string.Empty),
            new("signincount", user.SignInCount.ToString()),
        };
        sub.AddRange(user.UserRoles.Select(x => new Claim(ClaimTypes.Role, x.Name)));

        var signingKey = Encoding.UTF8.GetBytes(config.IssuerSigningKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new(sub),
            Issuer = config.ValidIssuer,
            Audience = config.ValidAudience,
            Expires = DateTime.UtcNow.AddMinutes(config.TokenLifetimeInMinutes),
            SigningCredentials = new(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature),
        };

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return jwt;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public RefreshToken GenerateRefreshToken(User user)
    {
        var config = options.Value.RefreshTokenOptions!;

        return new RefreshToken
        (
            Value: Guid.NewGuid().ToString(),
            ExpiresUtc: DateTime.UtcNow.AddMinutes(config.TokenLifetimeInMinutes)
        );
    }

    public Guid GetUserId(string accessToken)
    {
        var config = options.Value.JwtOptions!;

        var token = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);

        if (token.Issuer != config.ValidIssuer)
        {
            throw new ApplicationException("Invalid User");
        }

        var userId = token.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

        return userId is not null
            ? Guid.Parse(userId)
            : throw new ApplicationException("Invalid access token "+ accessToken);
    }
}