using Microsoft.AspNetCore.Identity;
using TodoAPI.Dtos.Auth;
using TodoAPI.Dtos.Auth.Request;
using TodoAPI.Dtos.Auth.Response;

namespace TodoAPI.Services;

public interface IJwtService
{
    Task<AuthResult> GenerateToken(IdentityUser user);
    Task<RefreshTokenResponseDTO> VerifyToken(TokenRequestDTO tokenRequest);
    
}
