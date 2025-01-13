namespace AEBestGatePath;

public class Journey
{
    public Journey(Astro source, Astro destination, IList<Astro> jgs)
    {
        Source = source;
        Destination = destination;
        foreach (var jg in jgs)
        {
            var dist = jg.DistanceTo(Destination);
            _jgMap.Add(jg, dist);
        }
    }
    public Astro Source { get; init; }
    public Astro Destination { get; init; }
    private Dictionary<Astro, decimal> _jgMap = new();

    public Stop GetShortestPath()
    {
        
        var n2 = true;
        var newPaths = new Dictionary<Stop, decimal>();
        var baseDistance = Source.DistanceTo(Destination);
        var root = new Stop(Source);
        newPaths.Add(root, baseDistance);
        
        Dictionary<Stop, decimal> paths = new();
        (decimal dist, Stop path) shortestPath = (baseDistance, root);
        while (n2)
        {
            var addedPaths = new Dictionary<Stop, decimal>();
            n2 = false;
            foreach (var path in newPaths)
            {
                n2 = true;
                paths.Add(path.Key, path.Value);
                if (path.Value < shortestPath.dist)
                    shortestPath = (path.Value, path.Key);
                var lastStop = path.Key.LastStop();

                var pathDist = path.Key.DistanceToEnd();
                // Console.WriteLine(distMap.Count(x => x.Key.Speed > lastStop.Node.Speed));
                // foreach (var jg in distMap)
                // {
                //     Console.WriteLine(jg);
                //     Console.WriteLine($"base path dist:{pathDist} + last stop to gate:{lastStop.Node.DistanceTo(jg.Key)} + dist to dest:{jg.Value} >< existing path size {path.Value}");
                // }
                foreach (var jg in _jgMap
                             .Where(x => x.Key.Speed > lastStop.Node.Speed)
                             .Where(x => pathDist + lastStop.Node.DistanceTo(x.Key) + x.Value < path.Value))
                {
                    addedPaths.Add(path.Key.Copy().AddStop(jg.Key), pathDist + lastStop.Node.DistanceTo(jg.Key) + jg.Value);
                }
            }
            newPaths = addedPaths;
        }
        return shortestPath.path.AddStop(Destination);
    }
    
    
    public Stop GetShortestPathShortcut()
    {
        
        var n2 = true;
        var newPaths = new Dictionary<Stop, decimal>();
        var baseDistance = Source.DistanceTo(Destination);
        var root = new Stop(Source);
        newPaths.Add(root, baseDistance);
        
        Dictionary<Stop, decimal> paths = new();
        (decimal dist, Stop path) shortestPath = (baseDistance, root);
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
                foreach (var jg in _jgMap
                             .Where(x => x.Key.Speed > lastStop.Node.Speed)
                             .Where(x => pathDist + lastStop.Node.DistanceTo(x.Key) + x.Value < shortestPath.dist))
                {
                    addedPaths.Add(path.Key.Copy().AddStop(jg.Key), pathDist + lastStop.Node.DistanceTo(jg.Key) + jg.Value);
                }
            }

            if (addedPaths.Count > 0)
            {
                var min = addedPaths.MinBy(x => x.Value);
                shortestPath = (min.Value, min.Key);
            }

            newPaths = addedPaths;
        }
        return shortestPath.path.AddStop(Destination);
    }
    
}