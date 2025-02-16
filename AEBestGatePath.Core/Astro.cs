﻿using System.Text.RegularExpressions;

namespace AEBestGatePath.Core;

public readonly partial record struct Astro
{
    private static readonly Regex LocationParser = LocationRegex();
    public Astro(string loc, int gateLevel = 0, int logiCommander = 0)
    {
        var m = LocationParser.Match(loc);
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

    public Astro(char server, int cluster, int galaxy, int regionX, int regionY, int systemX, int systemY, int ring, int ringPosition, int gateLevel, int logiCommander)
    {
        Server = server;
        Cluster = cluster;
        Galaxy = galaxy;
        RegionX = regionX;
        RegionY = regionY;
        SystemX = systemX;
        SystemY = systemY;
        Ring = ring;
        RingPosition = ringPosition;
        GateLevel = gateLevel;
        LogiCommander = logiCommander;
    }

    public char Server { get; }
    public int Cluster { get; }
    public int Galaxy { get; }

    public int LocationX => RegionX * 10 + SystemX;
    public int LocationY => RegionY * 10 + SystemY;
    public int GalaxyPosition => Cluster * 10 + Galaxy;

    public int RegionX { get; }
    public int RegionY { get; }
    public int SystemX { get; }
    public int SystemY { get; }
    public int Ring { get; }
    public int RingPosition { get; }
    public int GateLevel { get; }
    public int LogiCommander { get; }
    public override string ToString()
    {
        return $"{Server}{Cluster}{Galaxy}:{RegionX}{RegionY}:{SystemX}{SystemY}:{Ring}{RingPosition} - {GateLevel}:{LogiCommander}";
    }

    public bool Equals(Astro other)
    {
        return Server == other.Server && Cluster == other.Cluster && Galaxy == other.Galaxy && RegionX == other.RegionX && RegionY == other.RegionY && SystemX == other.SystemX && SystemY == other.SystemY && Ring == other.Ring && RingPosition == other.RingPosition;// && GateLevel == other.GateLevel && LogiCommander == other.LogiCommander;
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Server);
        hashCode.Add(Cluster);
        hashCode.Add(Galaxy);
        hashCode.Add(RegionX);
        hashCode.Add(RegionY);
        hashCode.Add(SystemX);
        hashCode.Add(SystemY);
        hashCode.Add(Ring);
        hashCode.Add(RingPosition);
        // hashCode.Add(GateLevel);
        // hashCode.Add(LogiCommander);
        return hashCode.ToHashCode();
    }

    public static bool operator ==(Astro? left, Astro? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Astro? left, Astro? right)
    {
        return !Equals(left, right);
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

    public decimal DistanceTo(Astro b, decimal version = 1)
    {
        if (Server != b.Server) return decimal.MaxValue;
        decimal distance = 0;
        // Galaxy Distance Calc
        if (IsDifferentGalaxy(b))
        {
            if (Cluster == b.Cluster)
                distance += Math.Abs(b.Galaxy - Galaxy) * 200;
            else if (version < 4)
            {
                if (b.Cluster < Cluster)
                {
                    distance += (Galaxy) * 200;
                    distance += 2000;
                    distance += (9 - b.Galaxy) * 200;
                }
                else if (b.Cluster > Cluster)
                {
                    distance += (9 - Galaxy) * 200;
                    distance += 2000;
                    distance += (b.Galaxy) * 200;
                }
            }
            else
            {
                throw new ApplicationException("Pumpkin map not implemented.");
            }
        }
        // System Distance Calc
        else if (IsDifferentSolarSystem(b))
        {
            //Console.WriteLine($"X{LocationX}, Y{LocationY}, RX{RegionX}, RY{RegionY}, SX{SystemX}, SY{SystemY}");
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

        return distance / Speed;
    }

    public bool Between(Astro a, Astro b, bool inclusive = true)
    {
        if (Cluster != a.Cluster && Cluster != b.Cluster)
            return false;
        var aVal = a.Cluster * 10 + a.Galaxy;
        var bVal = b.Cluster * 10 + b.Galaxy;
        if (inclusive)
            return Math.Min(aVal, bVal) <= Cluster * 10 + Galaxy && Cluster * 10 + Galaxy <= Math.Max(aVal, bVal);
        return Math.Min(aVal, bVal) < Cluster * 10 + Galaxy && Cluster * 10 + Galaxy < Math.Max(aVal, bVal);
    }

    public decimal Speed => this.Speed();

    [GeneratedRegex(@"^([A-Z])([0-9])([0-9]):([0-9])([0-9]):([0-9])([0-9]):([0-9])([0-9])$", RegexOptions.Compiled)]
    private static partial Regex LocationRegex();
}