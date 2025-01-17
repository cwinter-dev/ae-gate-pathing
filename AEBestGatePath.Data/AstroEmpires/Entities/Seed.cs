using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AEBestGatePath.Data.AstroEmpires.Entities;

[Index(nameof(Name), IsUnique = true)]
public class Seed
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
}