using Microsoft.AspNetCore.Identity;

namespace Serdiuk.Cloud.Api.Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task<IdentityUser> GetUserById(string id);
    }
}
