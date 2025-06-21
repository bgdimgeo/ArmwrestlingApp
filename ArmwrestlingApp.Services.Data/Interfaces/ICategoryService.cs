using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmwrestlingApp.ViewModels.Categorie;
using ArmwrestlingApp.ViewModels.Competition;

namespace ArmwrestlingApp.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> AddCategoryAsync(CategoryCreateViewModel model);

        Task<IEnumerable<CategoriesDetailsViewModel>> GetAllCategories();
    }
}
