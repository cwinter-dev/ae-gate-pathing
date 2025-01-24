using System.Text.RegularExpressions;

namespace AEBestGatePath.Core.Parsers;

public static class PlayerParser
{
    private static Regex PlayerRegex { get; } = new(@"(?:\[(.+)\]\s)?([^\t]+)\t[\s]+Player: ([0-9]+)", RegexOptions.Compiled);
    private static Regex GuildListRegex { get; } = new(@"([^\t]+)\s+Guild: ([0-9]+)\s+Tag: \[(.+)\]", RegexOptions.Compiled);
    public static IEnumerable<(int id, string name, string guildTag, string guildName, int guildGameId)> ParseUnknownList(string paste)
    {
        var profileMatch = PlayerRegex.Match(paste);
        if (profileMatch.Success)
        {
            return
            [
                (Convert.ToInt32(profileMatch.Groups[3].Value), profileMatch.Groups[2].Value,
                    profileMatch.Groups[1].Value, string.Empty, 0)
            ];
        }
        var guildListMatch = GuildListRegex.Match(paste);
        if (guildListMatch.Success)
        {
            var guildName = guildListMatch.Groups[1].Value;
            var gameId = Convert.ToInt32(guildListMatch.Groups[2].Value);
            var guildTag = guildListMatch.Groups[3].Value;
            return GuildListParser.ParsePlayerListFromGuildPaste(paste).Select(x => (x.id, x.name, guildTag, guildName, gameId));
        }
        throw new FormatException("Unknown player paste format");
    }
}