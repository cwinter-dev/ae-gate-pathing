using AEBestGatePath.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AEBestGatePath.Data.Context;

public class AstroEmpiresContext : DbContext
{
    public AstroEmpiresContext()
    {
    }

    public AstroEmpiresContext(DbContextOptions<AstroEmpiresContext> options) : base(options)
    {
    }
    public DbSet<Gate> Gates { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Guild> Guilds { get; set; }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Gate>(x =>
    //     {
    //         x.ComplexProperty(y => y.Location, y => y.IsRequired());
    //     });
    //     
    //     base.OnModelCreating(modelBuilder);
    // }
}