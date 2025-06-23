using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmwrestlingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArmwrestlingApp.Data.Configuration
{
    public class CompetitionCompetitorConfiguration : IEntityTypeConfiguration<CompetitionCategorie>
    {
        public void Configure(EntityTypeBuilder<CompetitionCategorie> builder)
        {
            builder.HasKey(c => new { c.CategoryId, c.CompetitionId });



             builder.HasOne(ur => ur.Category)
             .WithMany(u => u.CompetitionsCategories)
             .HasForeignKey(ur => ur.CategoryId);

            builder
                .HasOne(ur => ur.Competition)
                .WithMany(r => r.CompetitionsCategories)
                .HasForeignKey(ur => ur.CompetitionId);

            builder.HasQueryFilter(c => !c.IsDeleted);

        }
    }
}
