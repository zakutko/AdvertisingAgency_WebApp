using System.ComponentModel.DataAnnotations;

namespace IdentityMicroservice.DAL.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string? AboutInfo { get; set; }
        public int? NumberOfPublications { get; set; }
        public bool? IsOldUser { get; set; }
        public int RoleId { get; set; }
    }
}
