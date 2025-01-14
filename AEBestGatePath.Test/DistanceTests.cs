using AEBestGatePath.Core;

namespace AEBestGatePath.Test;

public class DistanceTests
{
    [Theory]
    [ClassData(typeof(DistanceTestData))]
    public void Distance(string location1, string location2, decimal expectedDistance)
    {
        Assert.Equal(expectedDistance, new Astro(location1).DistanceTo(new Astro(location2)));
    }
}