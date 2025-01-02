using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API.Authorization
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _secretKey;
        private readonly string? _validIssuer;
        private readonly string? _validAudience;
        private readonly double _expires;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<TokenService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration settings.</param>
        /// <param name="userManager">The user manager for managing user information.</param>
        /// <param name="logger">The logger for logging information.</param>
        /// <exception cref="InvalidOperationException">Thrown when JWT secret key is not configured.</exception>
        public TokenService(IConfiguration configuration, UserManager<IdentityUser> userManager, ILogger<TokenService> logger)
        {
            _userManager = userManager;
            _logger = logger;
            var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
            if (jwtSettings == null || string.IsNullOrEmpty(jwtSettings.Key))
            {
                throw new InvalidOperationException("JWT secret key is not configured.");
            }

            _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
            _validIssuer = jwtSettings.ValidIssuer;
            _validAudience = jwtSettings.ValidAudience;
            _expires = jwtSettings.Expires;
        }

        /// <summary>
        /// Generates a JWT token for the specified user.
        /// </summary>
        /// <param name="user">The user for whom the token is generated.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the generated JWT token.</returns>
        public async Task<string> GenerateToken(IdentityUser user)
        {
            var singingCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);
            var claims = await GetClaimsAsync(user);
            var tokenOptions = GenerateTokenOptions(singingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        /// <summary>
        /// Gets the claims for the specified user.
        /// </summary>
        /// <param name="user">The user for whom the claims are retrieved.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of claims.</returns>
        private async Task<List<Claim>> GetClaimsAsync(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user?.Id ?? string.Empty),
                new Claim(ClaimTypes.Email, user?.Email ?? string.Empty),
            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            return claims;
        }

        /// <summary>
        /// Generates the token options for the JWT token.
        /// </summary>
        /// <param name="signingCredentials">The signing credentials for the token.</param>
        /// <param name="claims">The claims to be included in the token.</param>
        /// <returns>The generated JWT token options.</returns>
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            return new JwtSecurityToken(
                issuer: _validIssuer,
                audience: _validAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_expires),
                signingCredentials: signingCredentials
            );
        }

        /// <summary>
        /// Generates a refresh token.
        /// </summary>
        /// <returns>The generated refresh token.</returns>
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            var refreshToken = Convert.ToBase64String(randomNumber);
            return refreshToken;
        }
    }

    public class JwtSettings
    {
        public string? Key { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public double Expires { get; set; }
    }
}