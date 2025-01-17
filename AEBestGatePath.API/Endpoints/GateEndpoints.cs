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

        group.MapGet("/paged", async (AstroEmpiresContext db, int page = 1, int itemsPerPage = 0,
            string? search = null, bool? occupied = null, string? sort = null, bool asc = true) =>
        {
            search = search?.ToLower();
            var query = db.Gates
                .Include(x => x.Player)
                .ThenInclude(x => x!.Guild)
                .Where(x => occupied == null || x.Occupied == occupied)
                .Where(x => search == null ||
                            (x.Name != null && x.Name.ToLower().Contains(search)) ||
                            ("" + x.Location.Server + x.Location.Cluster + x.Location.Galaxy + ':' + x.Location.RegionX + x.Location.RegionY + ':' + x.Location.SystemX + x.Location.SystemY + ':' + x.Location.Ring + x.Location.RingPosition).Contains(search));
            var paged = await Paged<Gate>.GetPaged(query, x => x.Id, page, itemsPerPage, sort, asc);

            return paged;
        });
        
        group.MapGet("/{id:guid}", async (Guid id, AstroEmpiresContext db) =>
            await db.Gates
                    .Include(x => x.Player)
                    .ThenInclude(x => x!.Guild)
                    .FirstOrDefaultAsync(x => x.Id == id)
                is { } gate
                ? Results.Ok(gate)
                : Results.NotFound())
            .Produces<Gate>();

        group.MapPost("/", async (Gate gate, AstroEmpiresContext db) =>
        {
            
            db.Gates.Add(gate);
            await db.SaveChangesAsync();

            return Results.Created($"/gates/{gate.Id}", gate);
        }).RequireAuthorization("admin");

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
        }).RequireAuthorization("admin");

        group.MapDelete("/{id:int}", async (int id, AstroEmpiresContext db) =>
        {
            if (await db.Gates.FindAsync(id) is not { } gate) return Results.NotFound();
            db.Gates.Remove(gate);
            await db.SaveChangesAsync();
            return Results.NoContent();

        }).RequireAuthorization("admin");
        
    }
}