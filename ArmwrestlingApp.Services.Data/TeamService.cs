using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmwrestlingApp.Data.Repository.Interfaces;
using ArmwrestlingApp.Models;
using ArmwrestlingApp.Services.Data.Interfaces;
using ArmwrestlingApp.ViewModels.Categorie;
using ArmwrestlingApp.ViewModels.Team;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArmwrestlingApp.Services.Data
{
    public class TeamService : BaseService, ITeamService
    {
        private readonly IRepository<Team, Guid> teamRepository;
        public TeamService(IHttpContextAccessor _httpContextAccessor, UserManager<ApplicationUser> _userManager, IRepository<Team, Guid> _teamRepository) 
            : base(_httpContextAccessor, _userManager)
        {
            this.teamRepository = _teamRepository;
        }

        public async Task<bool> AddTeamASync(CreateTeamViewModel model)
        {
            // Get user id 
            Guid userId = await GetCurrentUserIdAsync();

            if (userId == Guid.Empty)
            {
                return false;
            }

            Team team = new Team()
            {
                Name = model.Name,
                Town = model.Town,
                Country = model.Country,
                ImageUrl = model.ImageUrl
            };

            await this.teamRepository.AddAsync(team);

            return true;

        }

        public async Task<IEnumerable<CreateTeamViewModel>> GetAllTeamsAsync()
        {
            IEnumerable<CreateTeamViewModel> model = await this.teamRepository.GetAllAttachedNoTracking().Select(c=>new CreateTeamViewModel() 
            {
                 Name = c.Name,
                 Town = c.Town,
                 Country = c.Country,
                 ImageUrl = c.ImageUrl
            }).OrderBy(t=>t.Country).ThenBy(t=>t.Town).ToListAsync();

            return model;


        }
    }
}
