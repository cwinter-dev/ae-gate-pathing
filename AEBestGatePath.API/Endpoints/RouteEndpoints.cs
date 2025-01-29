using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using AEBestGatePath.Core;
using AEBestGatePath.Data.AstroEmpires.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AEBestGatePath.API.Endpoints;

public static class RouteEndpoints
{
    public static void MapRouteEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/{origin}/{destination}", async (string origin, string destination, int? gateLevel,
                int? commanderLevel, AstroEmpiresContext db, decimal gameVersion = 1m, Guid[]? usingGuilds = null) =>
            {
                var start = new Astro(origin, gateLevel ?? 0, commanderLevel ?? 0);

                if (gateLevel == null || commanderLevel == null)
                {
                    var existingLocation = await db.Gates.FirstOrDefaultAsync(x => x.Location.Server == start.Server &&
                        x.Location.Cluster == start.Cluster &&
                        x.Location.Galaxy == start.Galaxy &&
                        x.Location.RegionX == start.RegionX &&
                        x.Location.RegionY == start.RegionY &&
                        x.Location.SystemX == start.SystemX &&
                        x.Location.SystemY == start.SystemY &&
                        x.Location.Ring == start.Ring &&
                        x.Location.RingPosition == start.RingPosition);
                    start = new Astro(start.Server, start.Cluster, start.Galaxy, start.RegionX,
                        start.RegionY, start.SystemX, start.SystemY, start.Ring, start.RingPosition,
                        gateLevel ?? existingLocation?.Location.GateLevel ?? 0,
                        commanderLevel ?? existingLocation?.Location.LogiCommander ?? 0);
                }

                var dest = new Astro(destination);
                usingGuilds ??= [];

                // TODO: I hate hardcoding speed here
                // maybe move to db?
                // TODO: this will return multiple gates per galaxy if they have the same 'Speed', but it's not worth the extra join to fix
                var jgs = await (from g in db.Gates
                            .Include(x => x.Player)
                        join hg in from gr in db.Gates
                            join p in db.Players
                                on gr.PlayerId equals p.Id
                            where usingGuilds.Contains(p.GuildId.Value)
                            where !gr.Occupied
                            group gr by new { gr.Location.Cluster, gr.Location.Galaxy }
                            into hg
                                // We don't care about anything outside our cluster
                            where hg.Key.Cluster == dest.Cluster || hg.Key.Cluster == start.Cluster
                            // We're not including our current galaxy in this list 
                            where hg.Key.Cluster != start.Cluster || hg.Key.Galaxy != start.Galaxy
                            select new
                            {
                                Galaxy = hg.Key,
                                Speed = (from t in hg
                                    select (t.Location.GateLevel + 1) * (100 - t.Location.LogiCommander) * .01m).Max()
                            }
                            on new { g.Location.Cluster, g.Location.Galaxy } equals hg.Galaxy
                        where (g.Location.GateLevel + 1) * (100 - g.Location.LogiCommander) * .01m == hg.Speed
                        select g
                    ).Union(db.Gates
                        .Where(x => x.Location.Cluster == start.Cluster &&
                                    x.Location.Galaxy == start.Galaxy)
                        .Where(x => !x.Occupied)
                        .Where(x => (x.Location.GateLevel + 1) * (100 - x.Location.LogiCommander) * .01m >
                                    (start.GateLevel + 1) * (100 - start.LogiCommander) * .01m)
                        .Include(x => x.Player)
                        .Where(x => usingGuilds.Contains(x.Player!.GuildId!.Value)))
                    .Select(x => x.Location.ToAstro())
                    .ToListAsync();


                try
                {
                    Console.WriteLine($"Running with {jgs.Count} gates");
                    var journey = new Journey(start, dest, jgs, gameVersion);
                    return Results.Ok(journey.GetShortestPath());
                }
                catch (Exception ex)
                {
                    return Results.InternalServerError(new ApiError(ex.Message));
                }
            }).Produces<Stop>()
            .Produces<ApiError>(StatusCodes.Status500InternalServerError);
    }
}