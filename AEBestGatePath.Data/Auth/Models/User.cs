using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AEBestGatePath.Data.Auth.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string GoogleUid { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefershTokenExpiration { get; set; }
    }
}