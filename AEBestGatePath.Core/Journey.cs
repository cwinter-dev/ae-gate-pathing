namespace AEBestGatePath.Core;

public class Journey
{
    public Journey(Astro source, Astro destination, List<Astro> jgs, decimal gameVersion = 1)
    {
        Source = source;
        Destination = destination;
        GameVersion = gameVersion;
        _jgs = jgs;
    }

    public Astro Source { get; init; }
    public Astro Destination { get; init; }
    public decimal GameVersion { get; init; }
    private List<Astro> _jgs = new();

    public Stop GetShortestPath()
    {
        var n2 = true;
        var newPaths = new Dictionary<Stop, decimal>();
        var head = new Stop(Source, GameVersion);
        var foot = new Stop(Destination, GameVersion);

        Dictionary<Stop, decimal> paths = new();

        bool found;
        do
        {
            found = false;
            Func<Astro, bool>? beforeFoot = null;
            Func<Astro, bool>? afterHead = null;
            var footPosition = foot.Node.GalaxyPosition;
            var headPosition = head.Node.GalaxyPosition;
            if (head.Node.GalaxyPosition < foot.Node.GalaxyPosition)
            {
                beforeFoot = x => x.GalaxyPosition < footPosition;
                afterHead = x=> x.GalaxyPosition > headPosition;
            }
            else if (head.Node.GalaxyPosition > foot.Node.GalaxyPosition)
            {
                beforeFoot = x => x.GalaxyPosition > footPosition;
                afterHead = x=> x.GalaxyPosition < headPosition;
            }

            if (beforeFoot == null || afterHead == null) continue;
            var candidateJgs = _jgs.Where(beforeFoot).ToList(); 
            if (candidateJgs.Count == 0) continue;
            var highestSpeed = candidateJgs.Max(x => x.Speed);
            var stop = _jgs.Where(beforeFoot)
                .Where(afterHead)
                .Where(x => x.Speed > head.Node.Speed)
                .Where(x => x.Speed == highestSpeed)
                //Furthest distance
                .OrderByDescending(x => x.DistanceTo(foot.Node))
                .FirstOrDefault();
            if (stop == default) continue;
            found = true;
            foot = foot.AddPrevStop(stop);
        } while (found);

        Dictionary<Astro, decimal> jgMap = new();
        foreach (var jg in _jgs.Where(x => x.Cluster == Source.Cluster))
        {
            var dist = jg.DistanceTo(foot.Node);
            jgMap.Add(jg, dist);
        }

        var baseDistance = Source.DistanceTo(foot.Node, GameVersion);
        newPaths.Add(head, baseDistance);
        var shortestPath = new KeyValuePair<Stop, decimal>(head, baseDistance);

        while (n2)
        {
            var addedPaths = new Dictionary<Stop, decimal>();
            n2 = false;
            foreach (var path in newPaths)
            {
                n2 = true;
                paths.Add(path.Key, path.Value);
                var lastStop = path.Key.LastStop();

                var pathDist = path.Key.DistanceToEnd();
                // Console.WriteLine(distMap.Count(x => x.Key.Speed > lastStop.Node.Speed));
                // foreach (var jg in distMap)
                // {
                //     Console.WriteLine(jg);
                //     Console.WriteLine($"base path dist:{pathDist} + last stop to gate:{lastStop.Node.DistanceTo(jg.Key)} + dist to dest:{jg.Value} >< existing path size {path.Value}");
                // }
                foreach (var jg in jgMap
                             .Where(x => x.Key.Speed > lastStop.Node.Speed)
                             .Where(x => pathDist + lastStop.Node.DistanceTo(x.Key, GameVersion) + x.Value <
                                         shortestPath.Value))
                {
                    addedPaths.Add(path.Key.Copy().AddStop(jg.Key),
                        pathDist + lastStop.Node.DistanceTo(jg.Key, GameVersion) + jg.Value);
                }
            }

            if (addedPaths.Count > 0)
                shortestPath = addedPaths.MinBy(x => x.Value);
            newPaths = addedPaths;
        }

        return shortestPath.Key.Join(foot);
    }


    // public Stop GetShortestPathShortcut()
    // {
    //     
    //     var n2 = true;
    //     var newPaths = new Dictionary<Stop, decimal>();
    //     var baseDistance = Source.DistanceTo(Destination, GameVersion);
    //     var root = new Stop(Source, GameVersion);
    //     newPaths.Add(root, baseDistance);
    //     
    //     Dictionary<Stop, decimal> paths = new();
    //     (decimal dist, Stop path) shortestPath = (baseDistance, root);
    //     while (n2)
    //     {
    //         var addedPaths = new Dictionary<Stop, decimal>();
    //         n2 = false;
    //         foreach (var path in newPaths)
    //         {
    //             n2 = true;
    //             paths.Add(path.Key, path.Value);
    //             var lastStop = path.Key.LastStop();
    //
    //             var pathDist = path.Key.DistanceToEnd();
    //             // Console.WriteLine(distMap.Count(x => x.Key.Speed > lastStop.Node.Speed));
    //             // foreach (var jg in distMap)
    //             // {
    //             //     Console.WriteLine(jg);
    //             //     Console.WriteLine($"base path dist:{pathDist} + last stop to gate:{lastStop.Node.DistanceTo(jg.Key)} + dist to dest:{jg.Value} >< existing path size {path.Value}");
    //             // }
    //             foreach (var jg in _jgMap
    //                          .Where(x => x.Key.Speed > lastStop.Node.Speed)
    //                          .Where(x => pathDist + lastStop.Node.DistanceTo(x.Key, GameVersion) + x.Value < shortestPath.dist))
    //             {
    //                 addedPaths.Add(path.Key.Copy().AddStop(jg.Key), pathDist + lastStop.Node.DistanceTo(jg.Key, GameVersion) + jg.Value);
    //             }
    //         }
    //
    //         if (addedPaths.Count > 0)
    //         {
    //             var min = addedPaths.MinBy(x => x.Value);
    //             shortestPath = (min.Value, min.Key);
    //         }
    //
    //         newPaths = addedPaths;
    //     }
    //     return shortestPath.path.AddStop(Destination);
    // }
}