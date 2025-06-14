using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ArmwrestlingApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArmwrestlingApp.Data
{
    public class ArmwrestlingAppDbContext :
        IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ArmwrestlingAppDbContext()
        {

        }
        public ArmwrestlingAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<CompetitionCategorie> CompetitionsCategories { get; set; }
        public virtual DbSet<CompetitionCategorieCompetitor> CompetitionCategorieCompetitors { get; set; }
        public virtual DbSet<Competitor> Competitors { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
