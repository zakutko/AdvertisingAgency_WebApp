using System.ComponentModel.DataAnnotations;

namespace IdentityMicroservice.DAL.Models
{
    public class RoleRequest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public int NumberOfPublications { get; set; }
        [Required]
        public bool IsOldUser { get; set; }
    }
}
