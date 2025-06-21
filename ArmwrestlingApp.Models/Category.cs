using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArmwrestlingApp.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace ArmwrestlingApp.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        [Required]
        [Comment("The division of the category-junior, senior, master, grand master, disabled etc")]
        public Division Division { get; set; }

        [Required]
        [Comment("Gender of the category")]
        public Gender Gender { get; set; }

        [Required]
        [Comment("Category name")]
        public string Name { get; set; } = null!;

        [Comment("Category is deleted")]
        public bool IsDeleted { get; set; } = false;


        [Required]
        [Comment("Date on which the category was created")]
        public DateTime CreationDate { get; set; }

        [Comment("The last date on which the cartegory was changed")]
        public DateTime? LastChangeDate { get; set; }

        [Required]
        [Comment("Competition created by")]

        public Guid Creator_id { get; set; }

        [Required]
        [ForeignKey(nameof(Creator_id))]
        public ApplicationUser Creator { get; set; } = null!;

        [Required]
        [Comment("Competition changed by")]

        public Guid? Changer_id { get; set; }

        [ForeignKey(nameof(Changer_id))]
        public ApplicationUser? Changer { get; set; }



        public IEnumerable<CompetitionCategorieCompetitor> CompetitionCategoriesCompetitors { get; set; }
            = new HashSet<CompetitionCategorieCompetitor>();
        public IEnumerable<CompetitionCategorie> CompetitionsCategories { get; set; }
           = new HashSet<CompetitionCategorie>();

        //public ICollection<ArmwrestlingMatch> CategoriesMatches { get; set; }
        //    = new HashSet<ArmwrestlingMatch>();
    }
}