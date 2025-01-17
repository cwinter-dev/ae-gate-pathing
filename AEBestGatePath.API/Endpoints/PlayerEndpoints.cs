﻿using AEBestGatePath.Data.AstroEmpires.Context;
using AEBestGatePath.Data.AstroEmpires.Entities;
using Microsoft.EntityFrameworkCore;

namespace AEBestGatePath.API.Endpoints;


public static class PlayerEndpoints
{
    public static void MapPlayerEndpoints(this RouteGroupBuilder group)
    {
        
        group.MapGet("/", async (AstroEmpiresContext db) =>
            await db.Players.ToListAsync());
        
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