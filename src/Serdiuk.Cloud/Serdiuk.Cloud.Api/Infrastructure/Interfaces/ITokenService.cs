using Microsoft.AspNetCore.Identity;
using Serdiuk.Cloud.Api.Data.IdentityModels;

namespace Serdiuk.Cloud.Api.Infrastructure.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(IdentityUser user, IConfiguration config);
        string GenerateRefreshToken();
        Task<RefreshToken> GetRefreshTokenByTokenAsync(string token);
        Task AddNewRefreshToken(string token, string userId);
        void SetRevokedRefreshToken(RefreshToken refreshToken);
    }
}
