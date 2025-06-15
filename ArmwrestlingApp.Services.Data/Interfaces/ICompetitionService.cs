using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmwrestlingApp.ViewModels.Competition;

namespace ArmwrestlingApp.Services.Data.Interfaces
{
    public interface ICompetitionService
    {
         Task<CompetitionViewModel> GetCompetitionDetailsByIdAsync(Guid id);

        Task<IEnumerable<CompetitionViewModel>> IndexGetAllOrderedByDateAsync();

        Task<bool> AddCompetitionAsync(CompetitionCreateViewModel model);
    }
}
