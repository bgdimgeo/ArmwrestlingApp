using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ArmwrestlingApp.Common.Enums;
using Microsoft.EntityFrameworkCore;


namespace ArmwrestlingApp.Models
{
    public class Competition
    {
        [Key]
        [Comment("Unique Id of the competition")]
        public Guid Id { get; set; } = new Guid();

        [Required]
        [Comment("Competition Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Competition location name")]
        public string Location { get; set; } = null!;

        [Required]
        [Comment("Brief information about the competition")]
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

        [Required]
        [Comment("Date on which the competition was created")]
        public DateTime CreationDate { get; set; }

        [Comment("The last date on which the competionns was changed")]
        public DateTime? LastChangeDate { get; set; }

        [Required]
        [Comment("Competition created by")]

        public Guid Creator_id { get; set; }

        //[Required]
        //[ForeignKey(nameof(Creator_id))]
        //public ApplicationUser Creator { get; set; } = null!;

        //[Required]
        //[Comment("Competition changed by")]

        public Guid? Changer_id { get; set; }

        [ForeignKey(nameof(Changer_id))]
        public ApplicationUser? Changer { get; set; }

       
        //public ICollection<ArmwrestlingMatch> CompetionMatches { get; set; }
        //    = new HashSet<ArmwrestlingMatch>();

        [Comment("Competition is deleted")]
        public bool IsDeleted { get; set; } = false;


        [Url]
        [Comment("Url of the game image")]
        public string? ImageUrl { get; set; }

        [Comment("Competion is finished")]
        public bool Finished { get; set; } = false;

        [Required]
        public DateOnly Date { get; set; }
       
        public IEnumerable<CompetitionCategorieCompetitor> CompetitionCategoriesCompetitors { get; set; }
            = new HashSet<CompetitionCategorieCompetitor>();
        public IEnumerable<CompetitionCategorie> CompetitionsCategories { get; set; }
           = new HashSet<CompetitionCategorie>();



    }
}
