using AEBestGatePath.Core;
using AEBestGatePath.Data.AstroEmpires.Context;
using Microsoft.EntityFrameworkCore;

namespace AEBestGatePath.API.Endpoints;

public static class RouteEndpoints
{
    public static void MapRouteEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/{origin}/{destination}", async (string origin, string destination, int? gateLevel,
            int? commanderLevel, AstroEmpiresContext db, decimal gameVersion = 1m) =>
        {
            var jgs = await db.Gates.Where(x => !x.Occupied).Select(x => x.Location).Select(x => x.ToAstro()).ToListAsync();

            var start = new Astro(origin, gateLevel ?? 0, commanderLevel ?? 0);
            if (gateLevel == null || commanderLevel == null)
            {
                var existingLocation = await db.Gates.FirstOrDefaultAsync(x => x.Location.Server == start.Server &&
                                                                               x.Location.Cluster == start.Cluster &&
                                                                               x.Location.Galaxy == start.GateLevel &&
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

            var journey = new Journey(start, new Astro(destination), jgs, gameVersion);
            return journey.GetShortestPath();
        });
    }
}