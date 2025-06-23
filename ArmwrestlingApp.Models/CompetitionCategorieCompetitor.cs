using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArmwrestlingApp.Models
{
    public class CompetitionCategorieCompetitor
    {

        

        [Comment("Id of the competition")]
        public Guid CompetitionId { get; set; }
        [ForeignKey(nameof(CompetitionId))]
        public Competition Competition { get; set; } = null!;

        [Comment("Id of the category")]
        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
        [Comment("Id of the competitor")]
        public Guid CompetitorId { get; set; }
        [ForeignKey(nameof(CompetitorId))]
        public Competitor Competitor { get; set; } = null!;

        [Comment("Place in the ranking ")]
        public int Rank { get; set; }
        [Comment("Total Wins")]
        public int Wins { get; set; }
        [Comment("Total Loses")]
        public int Loses { get; set; }
        [Comment("Number used for the draw in the category")]
        public int DrawNumber { get; set; }

        [Comment("Category is deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
