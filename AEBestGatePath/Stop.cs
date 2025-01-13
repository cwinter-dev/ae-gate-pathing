using System.Text;

namespace AEBestGatePath;

public class Stop(Astro node)
{
    public Astro Node { get; init; } = node;
    public Stop? Next { get; private set; }
    public decimal DistanceToNext { get; private set; }

    public Stop AddStop(Astro node)
    {
        if (Next == null)
        {
            Next = new Stop(node);
            DistanceToNext = Node.DistanceTo(Next.Node);
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
        return new Stop(Node)
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