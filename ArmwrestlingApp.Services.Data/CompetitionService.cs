using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using ArmwrestlingApp.Data.Repository.Interfaces;
using ArmwrestlingApp.Models;
using ArmwrestlingApp.Services.Data.Interfaces;
using ArmwrestlingApp.ViewModels.Competition;
using Microsoft.EntityFrameworkCore;

namespace ArmwrestlingApp.Services.Data
{
    internal class CompetitionService : ICompetitionService
    {
        private readonly IRepository<Competition, Guid> competitionRepository;

        public CompetitionService(IRepository<Competition, Guid> _competitionRepository)
        {
            this.competitionRepository = _competitionRepository;
        }
        public async Task<CompetitionViewModel> GetCompetitionDetailsByIdAsync(Guid id)
        {
            Competition? competition = await this.competitionRepository.GetAllAttached()
                .Include(c => c.CompetitionsCategories).ThenInclude(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);

            if (competition != null) 
            {

            }
        }

        public Task<IEnumerable<CompetitionViewModel>> IndexGetAllOrderedByDateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
