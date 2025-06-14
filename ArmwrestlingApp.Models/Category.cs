using System.ComponentModel.DataAnnotations;
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


        public IEnumerable<CompetitionCategorieCompetitor> CompetitionCategoriesCompetitors { get; set; }
            = new HashSet<CompetitionCategorieCompetitor>();
        public IEnumerable<CompetitionCategorie> CompetitionsCategories { get; set; }
           = new HashSet<CompetitionCategorie>();

        //public ICollection<ArmwrestlingMatch> CategoriesMatches { get; set; }
        //    = new HashSet<ArmwrestlingMatch>();
    }
}