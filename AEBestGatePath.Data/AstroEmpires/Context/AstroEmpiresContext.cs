using AEBestGatePath.Core.Parsers;
using AEBestGatePath.Data.AstroEmpires.Entities;
using Microsoft.EntityFrameworkCore;

namespace AEBestGatePath.Data.AstroEmpires.Context;

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
    public DbSet<Seed> SeedData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSeeding((context, _) =>
            {
                var appliedSeeds = context.Set<Seed>().Select(x => x.Name).ToList().ToHashSet();
                var initialPlayersRawQuad = "../AEBestGatePath.Data/Migrations/Data/initialplayersrawquad.txt";
                if (!appliedSeeds.Contains(initialPlayersRawQuad))
                {
                    var players =
                        GuildListParser.ParsePlayerListFromGuildPaste(
                            File.ReadAllText(initialPlayersRawQuad));
                    var guild = context.Set<Guild>().FirstOrDefault(g => g.GameId == 12530);
                    context.Set<Player>().AddRange(players.Select(x => new Player
                    {
                        Name = x.name,
                        GameId = x.id,
                        GuildId = guild?.Id,
                        Guild = guild,
                    }));
                    context.Set<Seed>().Add(new Seed { Name = initialPlayersRawQuad });
                    context.SaveChanges();
                }
                var initialBasesRawQuad = "../AEBestGatePath.Data/Migrations/Data/initialbasesrawquad.txt";
                if (!appliedSeeds.Contains(initialPlayersRawQuad))
                {
                    var bases =
                        BaseListParser.ParseFromBaseReport(
                            File.ReadAllText(initialBasesRawQuad));
                    var pNames = bases.Select(y => y.playerName).Distinct();
                    var basePlayerMap =
                        context.Set<Player>().Where(x => pNames.Contains(x.Name))
                            .ToList().ToDictionary(x => x.Name, x => x.Id);
                    context.Set<Gate>().AddRange(bases.Select(x => new Gate
                    {
                        LastUpdated = DateTime.UtcNow,
                        Location = Location.FromAstro(x.astro),
                        Name = x.playerName,
                        PlayerId = basePlayerMap[x.playerName]
                    }));
                    context.Set<Seed>().Add(new Seed { Name = initialBasesRawQuad });
                    context.SaveChanges();
                }
            })
            .UseAsyncSeeding(async (context, _, cancellationToken) =>
            {
                var appliedSeeds = (await context.Set<Seed>().Select(x => x.Name).ToListAsync(cancellationToken: cancellationToken)).ToHashSet();
                var initialPlayersRawQuad = "../AEBestGatePath.Data/Migrations/Data/initialplayersrawquad.txt";
                if (!appliedSeeds.Contains(initialPlayersRawQuad))
                {
                    var players =
                        GuildListParser.ParsePlayerListFromGuildPaste(
                            await File.ReadAllTextAsync(initialPlayersRawQuad, cancellationToken));
                    var guild = context.Set<Guild>().FirstOrDefault(g => g.GameId == 12530);
                    await context.Set<Player>().AddRangeAsync(players.Select(x => new Player
                    {
                        Name = x.name,
                        GameId = x.id,
                        GuildId = guild?.Id,
                        Guild = guild,
                    }), cancellationToken);
                    await context.Set<Seed>().AddAsync(new Seed { Name = initialPlayersRawQuad }, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);
                }
                var initialBasesRawQuad = "../AEBestGatePath.Data/Migrations/Data/initialbasesrawquad.txt";
                if (!appliedSeeds.Contains(initialPlayersRawQuad))
                {
                    var bases =
                        BaseListParser.ParseFromBaseReport(
                            await File.ReadAllTextAsync(initialBasesRawQuad, cancellationToken));
                    var pNames = bases.Select(y => y.playerName).Distinct();
                    var basePlayerMap =
                        (await context.Set<Player>().Where(x => pNames.Contains(x.Name))
                            .ToListAsync(cancellationToken: cancellationToken)).ToDictionary(x => x.Name, x => x.Id);
                    await context.Set<Gate>().AddRangeAsync(bases.Select(x => new Gate
                    {
                        LastUpdated = DateTime.UtcNow,
                        Location = Location.FromAstro(x.astro),
                        Name = x.playerName,
                        PlayerId = basePlayerMap[x.playerName]
                    }), cancellationToken);
                    await context.Set<Seed>().AddAsync(new Seed { Name = initialBasesRawQuad }, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);
                }
            });
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Gate>(x =>
        // {
        //     x.ComplexProperty(y => y.Location, y => y.IsRequired());
        // });

        modelBuilder.Entity<Guild>().HasData(
            new Guild
            {
                Id = new Guid("b70b6921-9ee7-4cba-914f-c4bc619dc4b2"), Name = "actually four guilds", GameId = 12530
            },
            new Guild { Id = new Guid("17f9eba5-63bf-4ad0-9415-70b6e482fd7a"), Name = "CRUEL", GameId = 6469 });

        
        base.OnModelCreating(modelBuilder);
    }
}