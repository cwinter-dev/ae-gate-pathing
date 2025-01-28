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
            var startBox = start;
            // var localJgs = await db.Gates
            //     .Where(x => x.Location.Cluster == start1.Cluster &&
            //                 x.Location.Galaxy == start1.Galaxy)
            //     .Where(x => !x.Occupied)
            //     .Include(x => x.Player)
            //     .Where(x => usingGuilds == null || usingGuilds.Contains(x.Player!.GuildId!.Value))
            //     .Select(x => x.Location)
            //     .Select(x => x.ToAstro())
            //     .ToListAsync();

            // var regionalJgs = await db.Gates.GroupBy(x => new { x.Location.Cluster, x.Location.Galaxy })
            //     .Select(x => x.MaxBy(gr => Utils.Speed(gr.Location.GateLevel, gr.Location.LogiCommander)))
            //     .Select(x => x!.Location)
            //     .Select(x => x.ToAstro())
            //     .ToListAsync();


            // TODO: I hate hardcoding speed here
            // maybe move to db?
            var jgs = await (from g in db.Gates
                    .Include(x => x.Player)
                join hg in from gr in db.Gates
                    group gr by new { gr.Location.Cluster, gr.Location.Galaxy }
                    into hg
                    select new
                    {
                        Galaxy = hg.Key,
                        Speed = (from t in hg select (t.Location.GateLevel + 1) * (100 - t.Location.LogiCommander) * .01m).Max()
                    }
                    on new { g.Location.Cluster, g.Location.Galaxy } equals hg.Galaxy
                where (g.Location.GateLevel + 1) * (100 - g.Location.LogiCommander) * .01m == hg.Speed
                    select g
                ).Union(db.Gates
                    .Where(x => x.Location.Cluster == startBox.Cluster &&
                                x.Location.Galaxy == startBox.Galaxy)
                    .Where(x => !x.Occupied)
                    .Where(x => (x.Location.GateLevel + 1) * (100 - x.Location.LogiCommander) * .01m > (startBox.GateLevel + 1) * (100 - startBox.LogiCommander) * .01m)
                    .Include(x => x.Player)
                    .Where(x => usingGuilds == null || usingGuilds.Contains(x.Player!.GuildId!.Value)))
                .Select(x => x.Location.ToAstro())
                .ToListAsync();

            ;
                
                /*
                 *
                 * SELECT hg.*, g.* FROM "Gates" g
INNER JOIN (SELECT gr."Location_Cluster", gr."Location_Galaxy", MAX((gr."Location_GateLevel" + 1) * (100 - gr."Location_LogiCommander") * .01) Speed FROM "Gates" gr
GROUP BY gr."Location_Cluster", gr."Location_Galaxy") hg
ON hg."Location_Galaxy" = g."Location_Galaxy" AND hg."Location_Cluster" = g."Location_Cluster" AND hg.Speed = ((g."Location_GateLevel" + 1) * (100 - g."Location_LogiCommander") * .01)
                 */

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

            try
            {
                var journey = new Journey(start, new Astro(destination), jgs, gameVersion);
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