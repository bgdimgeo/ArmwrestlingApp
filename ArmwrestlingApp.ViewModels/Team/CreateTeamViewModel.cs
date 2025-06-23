using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArmwrestlingApp.ViewModels.Team
{
    public class CreateTeamViewModel
    {

        public string? Id { get; set; }

        [Required]
        [Comment("Name of the Team")]
        [MinLength(5)]
        [MaxLength(30)]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Name of the Town in which the team is")]
        [MinLength(5)]
        [MaxLength(30)]
        public string Town { get; set; } = null!;

        [Required]
        [Comment("Name of the Country in which the team is")]
        [MinLength(5)]
        [MaxLength(30)]
        public string Country { get; set; } = null!;

        [Url]
        [Display(Name = "Image URL")]
        [Comment("URL of the team logo or image")]
        public string? ImageUrl { get; set; }
    }
}
