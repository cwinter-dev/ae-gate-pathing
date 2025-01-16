using AEBestGatePath.Core;
using AEBestGatePath.Data.AstroEmpires.Context;
using AEBestGatePath.Data.AstroEmpires.Entities;
using Microsoft.EntityFrameworkCore;

namespace AEBestGatePath.API.Endpoints;

public static class GateEndpoints
{
    public static void MapGateEndpoints(this RouteGroupBuilder group)
    {
        
        group.MapGet("/", async (AstroEmpiresContext db) =>
            await db.Gates.ToListAsync());
        
        group.MapGet("/{id:int}", async (int id, AstroEmpiresContext db) =>
            await db.Gates.FindAsync(id)
                is { } gate
                ? Results.Ok(gate)
                : Results.NotFound());

        group.MapPost("/", async (Gate gate, AstroEmpiresContext db) =>
        {
            
            db.Gates.Add(gate);
            await db.SaveChangesAsync();

            return Results.Created($"/gates/{gate.Id}", gate);
        }).RequireAuthorization();

        group.MapPut("/{id:int}", async (int id, Gate inputGate, AstroEmpiresContext db) =>
        {
            var gate = await db.Gates.FindAsync(id);

            if (gate is null) return Results.NotFound();

            gate.Occupied = inputGate.Occupied;
            gate.LastUpdated = DateTime.UtcNow;
            gate.Location = new Location(gate.Location.Server, gate.Location.Cluster, gate.Location.Galaxy, gate.Location.RegionX,
                gate.Location.RegionY, gate.Location.SystemX, gate.Location.SystemY, gate.Location.Ring, gate.Location.RingPosition,
                inputGate.Location.GateLevel, inputGate.Location.LogiCommander);

            await db.SaveChangesAsync();

            return Results.NoContent();
        }).RequireAuthorization();

        group.MapDelete("/{id:int}", async (int id, AstroEmpiresContext db) =>
        {
            if (await db.Gates.FindAsync(id) is not { } gate) return Results.NotFound();
            db.Gates.Remove(gate);
            await db.SaveChangesAsync();
            return Results.NoContent();

        }).RequireAuthorization();
        
    }
}