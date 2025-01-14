﻿using AEBestGatePath.Data.Context;
using AEBestGatePath.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AEBestGatePath.API.Endpoints;


public static class GuildEndpoints
{
    public static void MapGuildEndpoints(this RouteGroupBuilder group)
    {
        
        group.MapGet("/", async (AstroEmpiresContext db) =>
            await db.Guilds.ToListAsync());
        
        group.MapGet("/{id:int}", async (int id, AstroEmpiresContext db) =>
            await db.Guilds.FindAsync(id)
                is { } guild
                ? Results.Ok(guild)
                : Results.NotFound());

        group.MapPost("/", async (Guild guild, AstroEmpiresContext db) =>
        {
            db.Guilds.Add(guild);
            await db.SaveChangesAsync();

            return Results.Created($"/guilds/{guild.Id}", guild);
        }).RequireAuthorization();

        group.MapPut("/{id:int}", async (int id, Guild inputGuild, AstroEmpiresContext db) =>
        {
            var guild = await db.Guilds.FindAsync(id);

            if (guild is null) return Results.NotFound();

            guild.Name = inputGuild.Name;

            await db.SaveChangesAsync();

            return Results.NoContent();
        }).RequireAuthorization();

        group.MapDelete("/{id:int}", async (int id, AstroEmpiresContext db) =>
        {
            if (await db.Guilds.FindAsync(id) is not { } guild) return Results.NotFound();
            db.Guilds.Remove(guild);
            await db.SaveChangesAsync();
            return Results.NoContent();

        }).RequireAuthorization();
        
    }
}