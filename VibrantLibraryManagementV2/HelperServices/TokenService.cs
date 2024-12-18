using System.IdentityModel.Tokens.Jwt;

namespace VibrantLibraryManagementV2.HelperServices
{
    public class TokenService
    {
        public bool IsTokenExpired(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var expirationDate = jwtToken.ValidTo;
            return expirationDate < DateTime.UtcNow;
        }

    }
}
