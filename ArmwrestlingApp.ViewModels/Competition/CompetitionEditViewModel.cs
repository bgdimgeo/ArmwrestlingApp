using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using ArmwrestlingApp.Common.Enums;

namespace ArmwrestlingApp.ViewModels.Competition
{
    public class CompetitionEditViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Comment("Competition Name")]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Competition location name")]
        [MaxLength(50)]
        public string Location { get; set; } = null!;

        [Required]
        [Comment("Brief information about the competition")]
        [MaxLength(400)]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("Competition Type")]
        public CompetitionType Type { get; set; }

        [Required]
        [Comment("Date on which the competition starts")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("Date on which the competition ends")]
        public DateTime EndDate { get; set; }

        [Url]
        [Comment("Url of the game image")]
        public string? ImageUrl { get; set; }


    }
}
