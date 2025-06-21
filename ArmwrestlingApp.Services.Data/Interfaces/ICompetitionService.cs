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
         Task<CompetitionDetailsViewModel> GetCompetitionDetailsByIdAsync(string id);

        Task<CompetitionListViewModel> GetAllCompetitionsOrderedByTypeAsync();

        Task<IEnumerable<CompetitionViewModel>> GetAllCompetitionsOrderedByDateAsync();

        Task<bool> AddCompetitionAsync(CompetitionCreateViewModel model);

        Task<CompetitionAddCategoryViewModel> GetCategoriesAsync(string id);
        


        Task<bool> AddCategoriesToCompetionAsync(CompetitionAddCategoryViewModel model);


        Task<CompetitionEditViewModel?> EditCompetitionAsync(string id);

        Task<bool> EditCompetitionAsync(CompetitionEditViewModel model);
    }
}
