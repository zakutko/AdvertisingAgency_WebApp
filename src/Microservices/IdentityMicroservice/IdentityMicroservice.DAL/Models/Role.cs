﻿using System.ComponentModel.DataAnnotations;

namespace IdentityMicroservice.DAL.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
