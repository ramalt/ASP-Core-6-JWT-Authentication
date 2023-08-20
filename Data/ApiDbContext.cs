using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI.Data;

public class ApiDbContext : IdentityDbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> opt) : base(opt)
    {

    }

    public virtual DbSet<Todo> Todos { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
}
