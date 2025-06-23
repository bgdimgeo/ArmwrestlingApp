using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmwrestlingApp.ViewModels.Categorie;
using ArmwrestlingApp.ViewModels.Competition;
using ArmwrestlingApp.ViewModels.Team;

namespace ArmwrestlingApp.Services.Data.Interfaces
{
    public interface ITeamService
    {
        Task<bool> AddTeamASync(CreateTeamViewModel model);

        Task<IEnumerable<CreateTeamViewModel>> GetAllTeamsAsync();

        
    }
}
