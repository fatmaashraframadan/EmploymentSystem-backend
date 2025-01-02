using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace API.Authorization
{
    public static class UserAuthorization
    {
        public static string ExtractUserId(string token)
        {
            // Initialize the JwtSecurityTokenHandler
            var tokenHandler = new JwtSecurityTokenHandler();

            // Read the token
            var jwtToken = tokenHandler.ReadJwtToken(token);

            // Extract the 'sub' claim (or 'UserId' depending on your setup)
            var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            return userId ?? "User ID not found";
        }
    }

}
