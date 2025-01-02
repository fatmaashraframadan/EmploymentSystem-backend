
using Microsoft.AspNetCore.Identity;

namespace API.Authorization
{
    public interface ITokenService
    {
        Task<string> GenerateToken(IdentityUser user);
        string GenerateRefreshToken();
    }
}