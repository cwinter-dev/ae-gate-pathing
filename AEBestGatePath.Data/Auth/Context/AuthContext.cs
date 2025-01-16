using AEBestGatePath.Data.Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace AEBestGatePath.Data.Auth.Context;

public class AuthContext : DbContext
{
    public AuthContext(DbContextOptions<AuthContext> options) : base(options)
    {
 
    }
 
    public DbSet<User> User { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {    
        modelBuilder.HasDefaultSchema("auth");
    }
}