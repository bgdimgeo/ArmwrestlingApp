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
    public class CompetitorConfiguration : IEntityTypeConfiguration<Competitor>
    {
        

        public void Configure(EntityTypeBuilder<Competitor> builder)
        {
            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
