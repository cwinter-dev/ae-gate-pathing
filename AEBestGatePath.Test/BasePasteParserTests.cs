using AEBestGatePath.Core;
using AEBestGatePath.Core.Parsers;

namespace AEBestGatePath.Test;

public class BasePasteParserTests
{
    [Theory]
    [ClassData(typeof(BasePasteParserTestData))]
    public void ParsePaste(string paste, BaseParser.ParsedBase expectedResult)
    {
        
        var parsedBase = BaseParser.ParseBasePaste(paste);
        
        Assert.Equal(expectedResult.Astro ,parsedBase.Astro);
        Assert.Equal(expectedResult.GuildTag, parsedBase.GuildTag);
        Assert.Equal(expectedResult.PlayerName, parsedBase.PlayerName);
        Assert.Equal(expectedResult.BaseName, parsedBase.BaseName);
        Assert.Equal(expectedResult.Occupied, parsedBase.Occupied);
        Assert.Equal(expectedResult.LastSeen, parsedBase.LastSeen);
        
    }
}