using System.Text;

namespace AEBestGatePath.Core;

public class Stop(Astro node, decimal gameVersion = 1)
{
    public Astro Node { get; init; } = node;
    public Stop? Next { get; private set; }
    public decimal DistanceToNext { get; private set; }
    public decimal GameVersion { get; init; }

    public Stop AddStop(Astro node)
    {
        if (Next == null)
        {
            Next = new Stop(node, GameVersion);
            DistanceToNext = Node.DistanceTo(Next.Node, GameVersion);
        }
        else
            Next.AddStop(node);

        return this;
    }
    
    public decimal DistanceToEnd()
    {
        return DistanceToNext + (Next?.DistanceToEnd() ?? 0);
    }

    public Stop Copy()
    {
        return new Stop(Node, GameVersion)
        {
            Next = Next?.Copy(),
            DistanceToNext = DistanceToNext
        };
    }

    public Stop LastStop()
    {
        return Next?.LastStop() ?? this;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{Node.ToString()} ({Node.Speed}) - {DistanceToNext:F} - {DistanceToEnd():F}");
        sb.Append(Next);
        return sb.ToString();
    }
    
    //
    // public decimal DistanceToStart()
    // {
    //     return Previous != null ? Previous.Node.DistanceTo(Node) : 0;
    // }
    //
    // public decimal TotalDistance()
    // {
    //     return DistanceToEnd() + DistanceToStart();
    // }
}