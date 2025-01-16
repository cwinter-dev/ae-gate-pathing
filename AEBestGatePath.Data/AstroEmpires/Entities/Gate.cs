using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AEBestGatePath.Data.AstroEmpires.Entities;

public class Gate
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid PlayerId { get; set; }
    public Player? Player { get; set; }
    public required Location Location { get; set; }
    public bool Occupied { get; set; } = false;
    public DateTime LastUpdated { get; set; }
}