using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ArmwrestlingApp.Models
{
    public class CompetitionCategorie
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        [Comment("Id of the competition")]
        public Guid CompetitionId { get; set; }
        [ForeignKey(nameof(CompetitionId))]
        public Competition Competition { get; set; } = null!;

        [Comment("Id of the category")]
        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Comment("Entry fee for the category")]
        public decimal EntryFee { get; set; }

        public  bool Finished { get; set; } = false;

        [Comment("Not assigned")]
        public bool IsDeleted { get; set; } = false;

    }
}