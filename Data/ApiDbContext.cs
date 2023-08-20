using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> opt) : base(opt)
    {

    }

    public virtual DbSet<Todo> Todos { get; set; }
}
