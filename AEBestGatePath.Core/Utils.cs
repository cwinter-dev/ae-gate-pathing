namespace AEBestGatePath.Core;

public static class Utils
{
    public static decimal Speed(this Astro astro)
    {
        return Speed(astro.GateLevel, astro.LogiCommander);
    }

    public static decimal Speed(int gateLevel, int commanderLevel)
    {
        return (gateLevel + 1) * (100 - commanderLevel) * .01m;
    }
}