using System.Collections;

namespace AEBestGatePath.Test;

public class DistanceTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        // same place
        yield return ["A70:51:45:10", "A70:51:45:10", 0];
        // different servers
        yield return ["A70:51:45:10", "B70:51:45:10", decimal.MaxValue];
        // same galaxy
        yield return ["A70:51:45:10", "A70:33:63:10", 026];
        yield return ["A00:00:00:00", "A00:99:99:00", 141];
        yield return ["A00:99:00:00", "A00:99:99:00", 13];
        yield return ["A00:00:99:00", "A00:99:99:00", 128];
        yield return ["A00:90:90:00", "A00:99:99:00", 99];
        yield return ["A00:09:09:00", "A00:99:99:00", 99];
        yield return ["A00:90:09:00", "A00:99:99:00", 91];
        yield return ["A00:09:90:00", "A00:99:99:00", 91];
        yield return ["A00:99:90:00", "A00:99:99:00", 9];
        yield return ["A00:90:99:00", "A00:99:99:00", 90];
        yield return ["A00:99:09:00", "A00:99:99:00", 9];
        yield return ["A00:09:99:00", "A00:99:99:00", 90];
        // same cluster
        yield return ["A70:51:45:10", "A71:65:32:10", 200];
        yield return ["A70:51:45:10", "A72:93:10:10", 400];
        yield return ["A70:51:45:10", "A73:44:00:12", 600];
        yield return ["A70:51:45:10", "A74:97:26:13", 800];
        yield return ["A70:51:45:10", "A75:20:87:31", 1000];
        yield return ["A70:51:45:10", "A77:28:98:12", 1400];
        yield return ["A70:51:45:10", "A78:54:67:11", 1600];
        yield return ["A70:51:45:10", "A79:51:98:12", 1800];
        // going down
        // different cluster
        yield return ["A70:33:63:10", "A69:41:63:10", 2000];
        yield return ["A70:33:63:10", "A68:76:07:21", 2200];
        yield return ["A70:33:63:10", "A67:97:34:22", 2400];
        yield return ["A70:33:63:10", "A66:65:45:11", 2600];
        yield return ["A70:33:63:10", "A65:22:82:11", 2800];
        yield return ["A70:33:63:10", "A64:82:16:31", 3000];
        yield return ["A70:33:63:10", "A63:78:41:20", 3200];
        yield return ["A70:33:63:10", "A62:06:91:20", 3400];
        yield return ["A70:33:63:10", "A61:29:94:11", 3600];
        yield return ["A70:33:63:10", "A60:56:94:20", 3800];
        // different cluster entry point
        yield return ["A71:16:67:11", "A69:41:63:10", 2200];
        yield return ["A71:16:67:11", "A68:76:07:21", 2400];
        yield return ["A71:16:67:11", "A67:97:34:22", 2600];
        yield return ["A71:16:67:11", "A66:65:45:11", 2800];
        yield return ["A71:16:67:11", "A65:22:82:11", 3000];
        yield return ["A71:16:67:11", "A64:82:16:31", 3200];
        yield return ["A71:16:67:11", "A63:78:41:20", 3400];
        yield return ["A71:16:67:11", "A62:06:91:20", 3600];
        yield return ["A71:16:67:11", "A61:29:94:11", 3800];
        yield return ["A71:16:67:11", "A60:56:94:20", 4000];
        // different cluster entry point
        yield return ["A72:47:30:10", "A69:41:63:10", 2400];
        yield return ["A72:47:30:10", "A68:76:07:21", 2600];
        yield return ["A72:47:30:10", "A67:97:34:22", 2800];
        yield return ["A72:47:30:10", "A66:65:45:11", 3000];
        yield return ["A72:47:30:10", "A65:22:82:11", 3200];
        yield return ["A72:47:30:10", "A64:82:16:31", 3400];
        yield return ["A72:47:30:10", "A63:78:41:20", 3600];
        yield return ["A72:47:30:10", "A62:06:91:20", 3800];
        yield return ["A72:47:30:10", "A61:29:94:11", 4000];
        yield return ["A72:47:30:10", "A60:56:94:20", 4200];
        // going up
        yield return ["A00:81:04:42", "A60:56:94:20", 3800];
        yield return ["A00:81:04:42", "A61:29:94:11", 4000];
        yield return ["A00:81:04:42", "A62:06:91:20", 4200];
        yield return ["A00:81:04:42", "A63:78:41:20", 4400];
        yield return ["A00:81:04:42", "A64:82:16:31", 4600];
        yield return ["A00:81:04:42", "A65:22:82:11", 4800];
        yield return ["A00:81:04:42", "A66:65:45:11", 5000];
        yield return ["A00:81:04:42", "A67:97:34:22", 5200];
        yield return ["A00:81:04:42", "A68:76:07:21", 5400];
        yield return ["A00:81:04:42", "A69:41:63:10", 5600];
        
        yield return ["A01:81:48:10", "A60:56:94:20", 3600];
        yield return ["A01:81:48:10", "A61:29:94:11", 3800];
        yield return ["A01:81:48:10", "A62:06:91:20", 4000];
        yield return ["A01:81:48:10", "A63:78:41:20", 4200];
        yield return ["A01:81:48:10", "A64:82:16:31", 4400];
        yield return ["A01:81:48:10", "A65:22:82:11", 4600];
        yield return ["A01:81:48:10", "A66:65:45:11", 4800];
        yield return ["A01:81:48:10", "A67:97:34:22", 5000];
        yield return ["A01:81:48:10", "A68:76:07:21", 5200];
        yield return ["A01:81:48:10", "A69:41:63:10", 5400];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}