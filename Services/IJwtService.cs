using Microsoft.AspNetCore.Identity;

namespace TodoAPI.Services;

public interface IJwtService
{
    string GenerateToken(IdentityUser user);
}
