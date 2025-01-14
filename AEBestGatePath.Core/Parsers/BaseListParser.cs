using System.Text.RegularExpressions;

namespace AEBestGatePath.Core.Parsers;

public static partial class BaseListParser
{
    private static Regex Regex { get; } = BaseReportRegex();
    public static List<(string playerName, string baseName, Astro astro)> ParseFromBaseReport(string baseReport)
    {
        List<(string playerName, string baseName, Astro astro)> baseList = new();
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
            var baseData = Regex.Match(line.Trim());
            baseList.Add((baseData.Groups[1].Value.Trim(), baseData.Groups[2].Value.Trim(),
                new Astro(baseData.Groups[3].Value.Trim())));
        }
        
        
        return baseList;
    }

    [GeneratedRegex(@"^(?:\[[A-Za-z]+\]\s)?(.+)\t(.+)\t([A-Z][0-9]{2}:[0-9]{2}:[0-9]{2}:[0-9]{2})$", RegexOptions.Compiled)]
    private static partial Regex BaseReportRegex();
}