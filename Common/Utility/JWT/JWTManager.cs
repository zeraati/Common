using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Common;
public static partial class Utility
{
    public static JWTInfo ReadJWT(JWTSetting jwtSetting, string token)
    {
        var secret = Encoding.UTF8.GetBytes(jwtSetting.Secret);
        var signingKey = new SymmetricSecurityKey(secret);

        var encryptionKey = Encoding.UTF8.GetBytes(jwtSetting.EncryptionKey);
        var decryptionKey = new SymmetricSecurityKey(encryptionKey);

        var handler = new JwtSecurityTokenHandler();
        var validations = new TokenValidationParameters
        {
            ValidIssuer = jwtSetting.Issuer,
            ValidAudience = jwtSetting.Audience,
            IssuerSigningKey = signingKey,
            TokenDecryptionKey = decryptionKey,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
        var claims = handler.ValidateToken(token, validations, out _).Claims;

        var result = new JWTInfo
        {
            UserId = claims.Where(x => x.Type == nameof(JWTInfo.UserId)).Select(x => long.Parse(x.Value)).First(),
            UserName = claims.Where(x => x.Type == nameof(JWTInfo.UserName)).Select(x => x.Value).First(),
            Mobile = claims.Where(x => x.Type == nameof(JWTInfo.Mobile)).Select(x => x.Value).First(),
            Role = claims.Where(x => x.Type == nameof(JWTInfo.Role)).Select(x => int.Parse(x.Value)).First(),
            LoginType = claims.Where(x => x.Type == nameof(JWTInfo.LoginType)).Select(x => int.Parse(x.Value)).First(),
        };

        var exp = claims.Where(x => x.Type == "exp").Select(x => long.Parse(x.Value)).First();
        result.ExpirationDate = DateTimeOffset.FromUnixTimeSeconds(exp).DateTime;

        return result;
    }
}
