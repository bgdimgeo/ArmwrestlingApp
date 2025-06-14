using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ArmwrestlingApp.Models
{
    public class Competitor
    {
        public Guid CompetitorId { get; set; }
        [ForeignKey(nameof(CompetitorId))]
        public ApplicationUser AppUser { get; set; } = null!;
        
        [Required]
        [Comment("Name of the competitor")]
        public string Name { get; set; } = null!;

        [Comment("Id of the team")]
        public Guid TeamId { get; set; }
        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; } = null!;

        public IEnumerable<CompetitionCategorieCompetitor> CompetitionCategoriesCompetitors { get; set; }
            = new HashSet<CompetitionCategorieCompetitor>();

    }
}
