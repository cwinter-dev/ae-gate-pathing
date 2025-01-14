namespace AEBestGatePath.Data.Entities;

public class Guild
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int GameId { get; set; }
    public List<Gate> Players { get; set; } = [];
}