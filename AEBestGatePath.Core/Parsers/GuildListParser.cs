namespace AEBestGatePath.Core.Parsers;

public static class GuildListParser
{
    public static List<(int id, string name)> ParsePlayerListFromGuildPaste(string guildPaste)
    {
        var players = new List<(int id, string name)>();
        var finishedPrefixes = false;
        foreach (var line in guildPaste.Trim().Split(Environment.NewLine))
        {
            if (!finishedPrefixes)
            {
                if (line.Trim() == "Economy")
                    finishedPrefixes = true;
                continue;
            }
            var playerData = line.Split('\t');
            players.Add((int.Parse(playerData[0]), playerData[^3]));
        }
        return players;
    }
}