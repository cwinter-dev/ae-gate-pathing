using System.Text.RegularExpressions;

partial class Astro
{
    private readonly Regex _regex = LocationRegex();
    public Astro(string loc, int gateLevel = 0, int logiCommander = 0)
    {
        var m = _regex.Match(loc);
        if (!m.Success) throw new ArgumentException("Unable to parse location: " + loc);
        Server = m.Groups[1].Value[0];
        if (int.TryParse(m.Groups[2].Value, out var cluster))
            Cluster = cluster;
        if (int.TryParse(m.Groups[3].Value, out var galaxy))
            Galaxy = galaxy;
        if (int.TryParse(m.Groups[4].Value, out var regionX))
            RegionX = regionX;
        if (int.TryParse(m.Groups[5].Value, out var regionY))
            RegionY = regionY;
        if (int.TryParse(m.Groups[6].Value, out var systemX))
            SystemX = systemX;
        if (int.TryParse(m.Groups[7].Value, out var systemY))
            SystemY = systemY;
        if (int.TryParse(m.Groups[8].Value, out var ring))
            Ring = ring;
        if (int.TryParse(m.Groups[9].Value, out var ringPosition))
            RingPosition = ringPosition;
        GateLevel = gateLevel;
        LogiCommander = logiCommander;
    }
    public char Server { get; private set; }
    public int Cluster { get; private set; }
    public int Galaxy { get; private set; }

    public int LocationX => RegionX * 10 + SystemX;
    public int LocationY => RegionY * 10 + SystemY;

    public int RegionX { get; private set; }
    public int RegionY { get; private set; }
    public int SystemX { get; private set; }
    public int SystemY { get; private set; }
    public int Ring { get; private set; }
    public int RingPosition { get; private set; }
    public int GateLevel { get; private set; }
    public int LogiCommander { get; private set; }
    public override string ToString()
    {
        return $"{Server}{Cluster}{Galaxy}:{RegionX}{RegionY}:{SystemX}{SystemY}:{Ring}{RingPosition}";
    }

    public bool IsDifferentGalaxy(Astro other)
    {
        return other.Galaxy != Galaxy || other.Cluster != Cluster;
    }

    public bool IsDifferentSolarSystem(Astro other)
    {
        return !IsDifferentGalaxy(other) && (
            other.RegionX != RegionX || 
            other.RegionY != RegionY ||
            other.SystemX != SystemX ||
            other.SystemY != SystemY);
    }

    public decimal DistanceBetween(Astro b)
    {
        decimal distance = 0;
        // Galaxy Distance Calc
        if (IsDifferentGalaxy(b))
        {
            if (Cluster != b.Cluster)
            {
                distance += 2000;
                distance += (9 - b.Galaxy) * 200;
            }
            else
            {
                distance += Math.Abs(b.Galaxy - Galaxy) * 200;
            }

        }
        // System Distance Calc
        else if (IsDifferentSolarSystem(b))
        {
            Console.WriteLine($"X{LocationX}, Y{LocationY}, RX{RegionX}, RY{RegionY}, SX{SystemX}, SY{SystemY}");
            distance += (decimal)Math.Ceiling(Math.Sqrt(Math.Pow(Math.Abs(LocationX - b.LocationX), 2) +
                                                        Math.Pow(Math.Abs(LocationY - b.LocationY), 2)));
        }
        else if (b.Ring != Ring)
        {
            distance += Math.Abs(b.Ring - Ring) * .2m;
        }
        else
        {
            distance += Math.Abs(b.RingPosition - RingPosition) * .1m;
        }

        return distance / (GateLevel + 1) * (100 - LogiCommander) * .01m;
    }

    [GeneratedRegex(@"^([A-Z])([0-9])([0-9]):([0-9])([0-9]):([0-9])([0-9]):([0-9])([0-9])$", RegexOptions.Compiled)]
    private static partial Regex LocationRegex();
}