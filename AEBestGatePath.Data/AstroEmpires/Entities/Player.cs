using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AEBestGatePath.Data.AstroEmpires.Entities;

[Index(nameof(Name), IsUnique = true)]
public class Player
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid? GuildId { get; set; }
    public Guild? Guild { get; set; }
    public required string Name { get; set; }
    public required int GameId { get; set; }
    public List<Gate> Gates { get; set; } = new();
}