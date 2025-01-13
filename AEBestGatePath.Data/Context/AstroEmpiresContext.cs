using AEBestGatePath.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AEBestGatePath.Data.Context;

public class AstroEmpiresContext
{
    public DbSet<Gate> Gates { get; set; }
    public DbSet<Player> Players { get; set; }
}