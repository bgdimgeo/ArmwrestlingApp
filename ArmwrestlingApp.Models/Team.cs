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

        [Required]
        [Comment("Name of the Town in which the team is")]
        public string Town { get; set; } = null!;


        [Required]
        [Comment("Name of the Country in which the team is")]
        public string Country { get; set; } = null!;


        [Comment("Team")]
        public bool IsDeleted { get; set; } = false;

        [Url]
        [Comment("Url of the game image")]
        public string? ImageUrl { get; set; }
    }
}