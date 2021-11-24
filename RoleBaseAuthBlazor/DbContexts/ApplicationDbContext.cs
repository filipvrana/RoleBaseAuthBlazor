using Microsoft.EntityFrameworkCore;
using RoleBaseAuthBlazor.Data;

namespace RoleBaseAuthBlazor.DbContexts
{
    public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Practice> Practices { get; set; }
}
}
