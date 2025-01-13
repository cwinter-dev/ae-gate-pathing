namespace AEBestGatePath.Data.Entities;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int GameId { get; set; }
    public List<Gate> Gates { get; set; } = new();
}