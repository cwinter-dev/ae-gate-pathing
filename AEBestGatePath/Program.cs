// See https://aka.ms/new-console-template for more information



/*
A69:41:63:10 18 A69:31:57:10 16 A69:41:89:10 16
A70:39:64:21 20 A70:40:68:11 18 A70:84:64:11 14
A71:46:58:20 15 A71:85:08:11 12 A71:58:33:12 12
A72:47:30:10 16 A72:60:99:40 14 A72:56:42:21 12
A73:61:85:21 16 A73:25:43:11 15 A73:52:62:11 13
A74:41:26:11 15 A74:41:26:30 14 A74:41:87:50 13
A75:20:87:21 16 A75:50:47:11 10 A75:62:95:10 08
A76:30:78:11 10 A76:61:40:10 09 A76:55:00:31 07
A77:43:14:11 18 A77:97:50:11 16 A77:05:96:11 13
A78:12:78:11 15 A78:58:02:11 13 A78:77:82:11 12
A79:84:62:32 13 A79:18:61:22 11 A79:63:83:20 10
 * 
 */

using System.Diagnostics;
using System.Xml.Linq;
using AEBestGatePath.Core;


// // Set admin privileges on the user corresponding to uid.
// var claims = new Dictionary<string, object>()
// {
//     { "admin", true },
// };
// var defaultApp = FirebaseApp.Create(new AppOptions
// {
//     Credential = GoogleCredential.FromFile(@"C:\Users\Chloe\Documents\keys\probable-byway-237515-f14db0b1db03.json")
// });
// var user = await FirebaseAuth.DefaultInstance
//     .GetUserByEmailAsync("c.winter1108@gmail.com");
// Console.WriteLine(user.Uid);
// await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync("104658258275825983602", claims);

var jgList = new List<Astro>();
var testLocs = "A68:76:07:21 11 A68:59:90:51 05 A69:41:63:10 18 A69:31:57:10 16 A69:41:89:10 16 A70:39:64:21 20 A70:40:68:11 18 A70:84:64:11 14 A71:46:58:20 15 A71:85:08:11 12 A71:58:33:12 12 A72:47:30:10 16 A72:60:99:40 14 A72:56:42:21 12 A73:61:85:21 16 A73:25:43:11 15 A73:52:62:11 13 A74:41:26:11 15 A74:41:26:30 14 A74:41:87:50 13 A75:20:87:21 16 A75:50:47:11 10 A75:62:95:10 08 A76:30:78:11 10 A76:61:40:10 09 A76:55:00:31 07 A77:43:14:11 18 A77:97:50:11 16 A77:05:96:11 13 A78:12:78:11 15 A78:58:02:11 13 A78:77:82:11 12 A79:84:62:32 13 A79:18:61:22 11 A79:63:83:20 10 ";
var astro = string.Empty;
foreach (var loc in testLocs.Split(' '))
{
    if (astro == string.Empty)
        astro = loc;
    else if (int.TryParse(loc, out var dist))
    {
        jgList.Add(new Astro(astro, dist));
        astro = string.Empty;
    }
    else
    {
        throw new ArgumentException("Error in string");
    }
}
/*
Console.WriteLine("Start loc:");
var start = new Astro(Console.ReadLine()?.Trim() ?? throw new InvalidOperationException());

Console.WriteLine("Destination:");
var dest = new Astro(Console.ReadLine()?.Trim() ?? throw new InvalidOperationException());

*/
var sw = new Stopwatch();
sw.Start();
//var start = new Astro("A79:51:98:12");
var dest = new Astro("A70:39:64:21");
var start = new Astro("A79:51:98:12");


var journey = new Journey(start, dest, jgList);
Console.WriteLine(sw.Elapsed.Milliseconds);
// var shortcutJourney = journey.GetShortestPathShortcut();
// Console.WriteLine(shortcutJourney);
// var e = shortcutJourney;
// while (e != null)
// {
//     Console.WriteLine(e.Node.DistanceTo(dest));
//     e = e.Next;
// }
Console.WriteLine(sw.Elapsed.Milliseconds);
var bruteJourney = journey.GetShortestPath();
Console.WriteLine(bruteJourney);
var e = bruteJourney;
while (e != null)
{
    Console.WriteLine(e.Node.DistanceTo(dest));
    e = e.Next;
}
Console.WriteLine(sw.Elapsed.Milliseconds);
sw.Stop();

// var finalPath = shortestPath.path.Copy().AddStop(dest);
// Console.WriteLine("min path");
// Console.WriteLine(paths.MinBy(x => x.Value).Key);
// Console.WriteLine();
// Console.WriteLine(finalPath);
// Console.WriteLine(finalPath.DistanceToEnd());
// Console.WriteLine(shortestPath.path);
// Console.WriteLine($"a{shortestPath.path.DistanceToEnd() + shortestPath.path.LastStop().Node.DistanceTo(dest)}");
//
// Console.WriteLine(start);
// Console.WriteLine(dest);
// Console.WriteLine(start.DistanceTo(dest));

/*
 * Within a cluster, it is always better to pick up speed going forward
 * going back to pick up speed needs to increase the total travel time by more than 200 per backtrack
 * 1. out of current galaxy
 * 2. out of current cluster
 * 3. into destination cluster
 * 4. into destination galaxy
 * 5. --into destination system--
 */