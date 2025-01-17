namespace AEBestGatePath.Web.Shared.Tables;

public class Paged<T>
{
    public List<T> Items { get; set; }
    public long Count { get; set; }
}