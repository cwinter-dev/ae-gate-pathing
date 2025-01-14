using System.ComponentModel.DataAnnotations.Schema;
using AEBestGatePath.Core;

namespace AEBestGatePath.Data.Entities;

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
}