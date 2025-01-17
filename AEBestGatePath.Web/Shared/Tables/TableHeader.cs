namespace AEBestGatePath.Web.Shared.Tables;

public class TableHeader<TItem>
{
    public string Name { get; set; }
    public Func<TItem, object> Sort { get; set; }
    public string SortPath { get; set; }
    public string Title { get; set; }
}