using AEBestGatePath.API.Client.Models;

namespace AEBestGatePath.Web.Utils;

public static class AstroUtils
{
    public static string FormatLocation(this Astro astro)
    {
        return $"{astro.Server}{astro.Cluster}{astro.Galaxy}:{astro.RegionX}{astro.RegionY}:{astro.SystemX}{astro.SystemY}:{astro.Ring}{astro.RingPosition}";
    }
    public static string Format(this Astro astro)
    {
        return astro.FormatLocation() + $" - {astro.GateLevel}:{astro.LogiCommander}";
    }
}