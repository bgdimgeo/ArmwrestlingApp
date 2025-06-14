using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ArmwrestlingApp.Models
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        [Required]
        [Comment("Name of the Team")]
        public string Name { get; set; } = null!;


        [Comment("Team")]
        public bool IsDeleted { get; set; } = false;
    }
}