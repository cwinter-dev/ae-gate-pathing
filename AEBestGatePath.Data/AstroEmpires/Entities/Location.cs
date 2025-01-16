using System.ComponentModel.DataAnnotations.Schema;
using AEBestGatePath.Core;

namespace AEBestGatePath.Data.AstroEmpires.Entities;

[ComplexType]
public record Location(
    char Server,
    int Cluster,
    int Galaxy,
    int RegionX,
    int RegionY,
    int SystemX,
    int SystemY,
    int Ring,
    int RingPosition,
    int GateLevel,
    int LogiCommander)
{

    public Astro ToAstro()
    {
        return new Astro(Server, Cluster, Galaxy, RegionX, RegionY, SystemX, SystemY, Ring, RingPosition, GateLevel, LogiCommander);
    }

    public static Location FromAstro(Astro astro)
    {
        return new Location(astro.Server, astro.Cluster, astro.Galaxy, astro.RegionX, astro.RegionY, astro.SystemX,
            astro.SystemY, astro.Ring, astro.RingPosition, astro.GateLevel, astro.LogiCommander);
    }
}