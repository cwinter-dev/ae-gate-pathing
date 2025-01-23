using System.Text.RegularExpressions;

namespace AEBestGatePath.Core.Parsers;

public static partial class BaseParser
{
    private static string[] _defenses =
    [
        "Barracks",
        "Laser Turrets",
        "Missile Turrets",
        "Plasma Turrets",
        "Ion Turrets",
        "Photon Turrets",
        "Disruptor Turrets",
        "Deflection Shields",
        "Planetary Shield",
        "Planetary Ring"
    ];

    public class ParsedBase(string playerName, string baseName, Astro astro) : IEquatable<ParsedBase>
    {
        public string? GuildTag { get; set; }
        public string PlayerName { get; set; } = playerName;
        public string BaseName { get; set; } = baseName;
        public bool Occupied { get; set; }
        public Astro Astro { get; set; } = astro;
        public TimeSpan LastSeen { get; set; } = TimeSpan.Zero;

        public bool Equals(ParsedBase? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return GuildTag == other.GuildTag && PlayerName == other.PlayerName && BaseName == other.BaseName &&
                   Occupied == other.Occupied && Astro.Equals(other.Astro) && LastSeen.Equals(other.LastSeen);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ParsedBase)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GuildTag, PlayerName, BaseName, Occupied, Astro, LastSeen);
        }
    }

    private static Regex BaseImport { get; } = BaseReportRegex();
    private static Regex BaseOwner { get; } = BaseOwnerRegex();
    private static Regex BaseCommander { get; } = BaseCommanderRegex();
    private static Regex RecordedData { get; } = RecordedDataRegex();

    public static List<ParsedBase> ParseListFromBaseReport(string baseReport)
    {
        List<ParsedBase> baseList = [];
        var foundPrefixes = 0;
        var prefixes = new List<string>()
        {
            "Player",
            "Base",
            "Location"
        };
        foreach (var line in baseReport.Trim().Split(Environment.NewLine))
        {
            if (foundPrefixes < prefixes.Count)
            {
                if (line.Trim() == prefixes[foundPrefixes])
                    foundPrefixes++;
                else
                    foundPrefixes = 0;
                continue;
            }

            var baseData = BaseImport.Match(line.Trim());
            baseList.Add(new(baseData.Groups[1].Value.Trim(), baseData.Groups[2].Value.Trim(),
                new Astro(baseData.Groups[3].Value.Trim())));
        }


        return baseList;
    }

    public static ParsedBase ParseBasePaste(string baseReport)
    {
        var addingStructures = false;
        var structureIx = 0;
        List<(string, int)> structures = new();
        bool? recorded = null;
        var prevLine = string.Empty;
        string baseName = string.Empty, location = string.Empty, playerName = string.Empty;
        string? guildTag = null;
        int? jgLevel = null, logiLevel = null;
        var lastSeen = TimeSpan.Zero;
        var occupied = false;

        foreach (var l in baseReport.Trim().Split(Environment.NewLine))
        {
            var line = l.Trim();
            if (line == string.Empty) continue;

            if (baseName == string.Empty)
            {
                if (line.StartsWith("Location:"))
                {
                    baseName = prevLine;
                    location = line.Split(' ').Last();
                    recorded = true;
                }
                else if (prevLine.StartsWith("Base Name"))
                {
                    var baseInfo = line.Split('\t');
                    baseName = baseInfo[0];
                    location = baseInfo[1];
                    recorded = false;
                }
                else if (line.StartsWith("Location"))
                {
                    baseName = prevLine;
                }

                prevLine = line;
                continue;
            }

            if (location == string.Empty)
            {
                if (prevLine == "Disband")
                {
                    location = line.Split('\t').First();
                }

                prevLine = line;
                continue;
            }

            if (playerName == string.Empty)
            {
                var ownerInfo = BaseOwner.Match(line);
                if (ownerInfo.Success)
                {
                    if (ownerInfo.Groups[1].Value != string.Empty)
                        guildTag = ownerInfo.Groups[1].Value;
                    playerName = ownerInfo.Groups[2].Value;
                }

                continue;
            }

            if (!occupied)
            {
                if (line.StartsWith("Occupier"))
                    occupied = true;
            }

            if (logiLevel == null)
            {
                var commanderInfo = BaseCommander.Match(line);
                if (commanderInfo.Success)
                {
                    logiLevel = commanderInfo.Groups[1].Value == "Logistics"
                        ? int.Parse(commanderInfo.Groups[2].Value)
                        : 0;
                }
            }

            if (recorded == true && lastSeen == TimeSpan.Zero)
            {
                var recordedInfo = RecordedData.Match(line);
                if (recordedInfo.Success)
                {
                    lastSeen = recordedInfo.Groups[2].Value switch
                    {
                        "hour" => new TimeSpan(int.Parse(recordedInfo.Groups[1].Value), 0, 0),
                        "day" => new TimeSpan(int.Parse(recordedInfo.Groups[1].Value), 0, 0, 0),
                        _ => throw new ApplicationException("Unknown recorded time")
                    };
                }

                continue;
            }


            if (addingStructures)
            {
                if (char.IsDigit(line[0]))
                {
                    structures[structureIx] = (structures[structureIx].Item1, int.Parse(line));
                    structureIx++;
                }
                else if (!_defenses.Contains(line))
                    structures.Add((line, 0));
                else
                    addingStructures = false;
            }
            else if (line.StartsWith("Structures"))
                addingStructures = true;
        }

        jgLevel = structures.FirstOrDefault(x => x.Item1 == "Jump Gate").Item2;

        var parsed = new ParsedBase(playerName, baseName, new Astro(location, jgLevel.Value, logiLevel ?? 0))
            { GuildTag = guildTag, LastSeen = lastSeen, Occupied = occupied };

        return parsed;

        //baseReport = baseReport.Trim();
        //var recorded = baseReport.Contains("Recorded data from");

        // if (recorded)
        // {
        //     
        // }
        // else
        // {
        //     
        // }
        //
        // throw new NotImplementedException();
    }

    [GeneratedRegex(@"^(?:\[[A-Za-z]+\]\s)?(.+)\t(.+)\t([A-Z][0-9]{2}:[0-9]{2}:[0-9]{2}:[0-9]{2})$",
        RegexOptions.Compiled)]
    private static partial Regex BaseReportRegex();

    [GeneratedRegex(@"^Base Owner:?\s+(?:\[(.+)\]\s)?(.+)$", RegexOptions.Compiled)]
    private static partial Regex BaseOwnerRegex();

    [GeneratedRegex(@"^\s+Base Commander: [A-Za-z\s]+\(([A-za-z]+)\s([0-9]{1,2})\)\s+$", RegexOptions.Compiled)]
    private static partial Regex BaseCommanderRegex();

    [GeneratedRegex(@"^Recorded data from ([0-9]+) ([a-z]+)\(s\) ago.$", RegexOptions.Compiled)]
    private static partial Regex RecordedDataRegex();
}