using AEBestGatePath.Core.Parsers;
using AEBestGatePath.Data.AstroEmpires.Context;
using AEBestGatePath.Data.AstroEmpires.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AEBestGatePath.API.Endpoints;


public static class PlayerEndpoints
{
    public static void MapPlayerEndpoints(this RouteGroupBuilder group)
    {
        
        group.MapGet("/", async (AstroEmpiresContext db) =>
            await db.Players.ToListAsync());

        group.MapGet("/paged", async (AstroEmpiresContext db, int page = 1, int itemsPerPage = 0,
            string? search = null, Guid? guild = null, string? sort = null, bool asc = true) =>
        {
            search = search?.ToLower();
            var query = db.Players
                .Include(x => x!.Guild)
                .Where(x => guild == null || guild == x.GuildId)
                .Where(x => string.IsNullOrEmpty(search) ||
                            x.Name.ToLower().Contains(search));
            var paged = await Paged<Player>.GetPaged(query, x => x.Id, page, itemsPerPage, sort, asc);

            return paged;
        });
        
        group.MapGet("/{id:guid}", async (Guid id, AstroEmpiresContext db) =>
            await db.Players.FindAsync(id)
                is { } player
                ? Results.Ok(player)
                : Results.NotFound())
            .Produces<Player>();

        group.MapPost("/", async (Player player, AstroEmpiresContext db) =>
        {
            db.Players.Add(player);
            await db.SaveChangesAsync();

            return Results.Created($"/players/{player.Id}", player);
        }).RequireAuthorization("admin");


        group.MapPost("/paste", async ([FromBody] string paste, AstroEmpiresContext db) =>
        {
            var parsed = PlayerParser.ParseUnknownList(paste);
            Guild? guild = null;
            
            foreach (var player in parsed)
            {
                if (player.guildTag != string.Empty && guild == null)
                {
                    guild = await db.Guilds.FirstOrDefaultAsync(x => x.Tag == player.guildTag);
                    if (guild == null)
                    {
                        if (player.guildGameId != 0)
                        {
                            guild = new()
                            {
                                Tag = player.guildTag,
                                Name = player.guildName,
                                GameId = player.guildGameId
                            };
                            db.Guilds.Add(guild);
                            await db.SaveChangesAsync();
                        }
                        else
                        {
                            return Results.InternalServerError(new ApiError($"Guild tag {player.guildTag} not found"));
                        }
                    }
                }
                var existingPlayer = db.Players.FirstOrDefault(x => x.GameId == player.id);
                if (existingPlayer == null)
                {
                    db.Players.Add(new()
                    {
                        GameId = player.id,
                        Name = player.name,
                        Guild = guild,
                    });
                }
                else
                {
                    existingPlayer.Name = player.name;
                    existingPlayer.Guild = guild;
                    existingPlayer.GuildId = guild?.Id;
                }
            }
            await db.SaveChangesAsync();
            
            return Results.NoContent();
            
        }).Produces(StatusCodes.Status204NoContent)
            .Produces<ApiError>(StatusCodes.Status500InternalServerError)
            .RequireAuthorization("admin");

        group.MapPut("/{id:int}", async (int id, Player inputPlayer, AstroEmpiresContext db) =>
        {
            var player = await db.Players.FindAsync(id);

            if (player is null) return Results.NotFound();

            player.Name = inputPlayer.Name;
            player.GuildId = inputPlayer.GuildId;

            await db.SaveChangesAsync();

            return Results.NoContent();
        }).RequireAuthorization("admin");

        group.MapDelete("/{id:int}", async (int id, AstroEmpiresContext db) =>
        {
            if (await db.Players.FindAsync(id) is not { } player) return Results.NotFound();
            db.Players.Remove(player);
            await db.SaveChangesAsync();
            return Results.NoContent();

        }).RequireAuthorization("admin");
        
    }
}