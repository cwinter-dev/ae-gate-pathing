using AEBestGatePath.Core;
using AEBestGatePath.Core.Parsers;
using AEBestGatePath.Data.AstroEmpires.Context;
using AEBestGatePath.Data.AstroEmpires.Entities;
using Microsoft.AspNetCore.Mvc;
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

        group.MapGet("/outdated", async (AstroEmpiresContext db) =>
        {
            return await db.Gates.CountAsync(x => x.LastUpdated == DateTime.MinValue || DateTime.UtcNow - x.LastUpdated > TimeSpan.FromDays(30));
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
        
        group.MapGet("/{loc}", async (string loc, AstroEmpiresContext db) =>
        {
            var location = new Astro(loc);
            var gate = await db.Gates.FirstOrDefaultAsync(x =>
                x.Location.Server == location.Server &&
                x.Location.Cluster == location.Cluster &&
                x.Location.Galaxy == location.Galaxy &&
                x.Location.RegionX == location.RegionX &&
                x.Location.RegionY == location.RegionY &&
                x.Location.SystemX == location.SystemX &&
                x.Location.SystemY == location.SystemY &&
                x.Location.Ring == location.Ring &&
                x.Location.RingPosition == location.RingPosition);
            
            return gate == null ? Results.NotFound() : Results.Redirect($"/gates/{gate.Id}", true, true);
        }).Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status307TemporaryRedirect)
            .Produces(StatusCodes.Status308PermanentRedirect);

        group.MapPost("/", async (Gate gate, AstroEmpiresContext db) =>
        {
            
            db.Gates.Add(gate);
            await db.SaveChangesAsync();

            return Results.Created($"/gates/{gate.Id}", gate);
        }).RequireAuthorization("admin");


        group.MapPost("/paste", async ([FromBody] string paste, AstroEmpiresContext db) =>
        {
            
            BaseParser.ParsedBase parsed;
            try
            {
                parsed = BaseParser.ParseBasePaste(paste);
            }
            catch (Exception ex)
            {
                return Results.InternalServerError(new ApiError(ex.Message));
            }
            var player = db.Players.FirstOrDefault(x => x.Name == parsed.PlayerName);
            if (player == null)
                return Results.NotFound(new ApiError($"Player {parsed.PlayerName} not found"));
            var location = Location.FromAstro(parsed.Astro);

            var existingGate = await db.Gates.Include(x => x.Player).FirstOrDefaultAsync(x =>
                x.Location.Server == location.Server &&
                x.Location.Cluster == location.Cluster &&
                x.Location.Galaxy == location.Galaxy &&
                x.Location.RegionX == location.RegionX &&
                x.Location.RegionY == location.RegionY &&
                x.Location.SystemX == location.SystemX &&
                x.Location.SystemY == location.SystemY &&
                x.Location.Ring == location.Ring &&
                x.Location.RingPosition == location.RingPosition);

            if (existingGate == null)
            {

                var gate = new Gate
                {
                    Player = player,
                    PlayerId = player.Id,
                    LastUpdated = DateTime.UtcNow - parsed.LastSeen,
                    Occupied = parsed.Occupied,
                    Location = location,
                    Name = parsed.BaseName
                };
                db.Gates.Add(gate);
                await db.SaveChangesAsync();

                return Results.Created($"/gates/{gate.Id}", gate);
            }

            existingGate.Location = location;
            existingGate.Occupied = parsed.Occupied;
            existingGate.LastUpdated = DateTime.UtcNow - parsed.LastSeen;
            existingGate.Player = player;
            existingGate.PlayerId = player.Id;
            existingGate.Name = parsed.BaseName;
            existingGate.Location = location;
            await db.SaveChangesAsync();
            
            return Results.Ok(existingGate);
            
        }).Produces<Gate?>()
            .Produces<ApiError>(StatusCodes.Status500InternalServerError)
            .Produces<ApiError>(StatusCodes.Status404NotFound)
            .Produces<Gate?>(StatusCodes.Status201Created)
            .RequireAuthorization("admin");
        
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

        group.MapDelete("/{id:Guid}", async (Guid id, AstroEmpiresContext db) =>
        {
            if (await db.Gates.FindAsync(id) is not { } gate) return Results.NotFound();
            db.Gates.Remove(gate);
            await db.SaveChangesAsync();
            return Results.NoContent();

        }).RequireAuthorization("admin");
        
    }
}