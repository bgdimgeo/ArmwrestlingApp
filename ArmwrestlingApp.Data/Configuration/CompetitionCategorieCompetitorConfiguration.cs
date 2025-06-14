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
        }
    }
}
