using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AEBestGatePath.Data.Auth.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public required string ExternalId { get; set; }
        public required string Username { get; set; }
        public string? Email { get; set; }
        public string? ProfilePicture { get; set; }
        public int SignInCount { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiresUtc { get; set; }
        public List<UserRoles> UserRoles { get; set; } = [];
    }
}