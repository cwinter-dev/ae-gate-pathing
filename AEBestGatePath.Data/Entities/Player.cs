﻿namespace AEBestGatePath.Data.Entities;

public class Player
{
    public int Id { get; set; }
    public int? GuildId { get; set; }
    public Guild? Guild { get; set; }
    public required string Name { get; set; }
    public required int GameId { get; set; }
    public List<Gate> Gates { get; set; } = new();
}