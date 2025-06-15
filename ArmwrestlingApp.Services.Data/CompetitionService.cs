using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using ArmwrestlingApp.Data.Repository.Interfaces;
using ArmwrestlingApp.Models;
using ArmwrestlingApp.Services.Data.Interfaces;
using ArmwrestlingApp.ViewModels.Competition;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArmwrestlingApp.Services.Data
{
    internal class CompetitionService : BaseService, ICompetitionService
    {
        private readonly IRepository<Competition, Guid> competitionRepository;
        

        public CompetitionService(IRepository<Competition, Guid> _competitionRepository, UserManager<ApplicationUser> _userManager, IHttpContextAccessor _httpContextAccessor) :
            base(_httpContextAccessor, _userManager)
        {
            this.competitionRepository = _competitionRepository;
        }

        public async Task<bool> AddCompetitionAsync(CompetitionCreateViewModel model)
        {
            // Get user id 
            Guid userId = await GetCurrentUserIdAsync();

            if (userId == Guid.Empty) 
            {
                return false;
            }
            


            Competition competition = new Competition() 
            {
                Name = model.Name,
                Location = model.Location,
                Description = model.Description,
                Type = model.Type,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                ImageUrl = model.ImageUrl,
                Creator_id = userId,
                Changer_id = userId,
                CreationDate = DateTime.UtcNow,
                LastChangeDate = DateTime.UtcNow,
                Finished = false
            };

            await this.competitionRepository.AddAsync(competition);

            return true;

        }

        public async Task<CompetitionViewModel> GetCompetitionDetailsByIdAsync(Guid id)
        {
            Competition? competition = await this.competitionRepository.GetAllAttached()
                .Include(c => c.CompetitionsCategories).ThenInclude(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);

            CompetitionViewModel competitionViewModel = null;

            if (competition != null) 
            {

            }

            return competitionViewModel;
        }

        public Task<IEnumerable<CompetitionViewModel>> IndexGetAllOrderedByDateAsync()
        {
            throw new NotImplementedException();
        }

    }
}
