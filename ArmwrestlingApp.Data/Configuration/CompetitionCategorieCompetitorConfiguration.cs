using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmwrestlingApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ArmwrestlingApp.Data.Configuration
{
    public class CompetitionCategorieCompetitorConfiguration : IEntityTypeConfiguration<CompetitionCategorieCompetitor>
    {
        public void Configure(EntityTypeBuilder<CompetitionCategorieCompetitor> builder)
        {
            builder.HasKey(n => new { n.CompetitorId, n.CategoryId, n.CompetitionId });


            builder.HasOne(ur => ur.Category)
            .WithMany(u => u.CompetitionCategoriesCompetitors)
            .HasForeignKey(ur => ur.CategoryId);

            builder
                .HasOne(ur => ur.Competition)
                .WithMany(r => r.CompetitionCategoriesCompetitors)
                .HasForeignKey(ur => ur.CompetitionId);


            builder
               .HasOne(ur => ur.Competitor)
               .WithMany(r => r.CompetitionCategoriesCompetitors)
               .HasForeignKey(ur => ur.CompetitorId);


            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
