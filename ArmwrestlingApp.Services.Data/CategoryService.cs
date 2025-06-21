using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmwrestlingApp.Data.Repository.Interfaces;
using ArmwrestlingApp.Models;
using ArmwrestlingApp.Services.Data.Interfaces;
using ArmwrestlingApp.ViewModels.Categorie;
using ArmwrestlingApp.ViewModels.Competition;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArmwrestlingApp.Services.Data
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IRepository<Category, Guid> categoryRepository;
        public CategoryService(IHttpContextAccessor _httpContextAccessor, UserManager<ApplicationUser> _userManager, IRepository<Category, Guid> _categoryRepository) 
            : base(_httpContextAccessor, _userManager)
        {
            categoryRepository = _categoryRepository;
        }

        public async Task<bool> AddCategoryAsync(CategoryCreateViewModel model)
        {
            // Get user id 
            Guid userId = await GetCurrentUserIdAsync();

            if (userId == Guid.Empty)
            {
                return false;
            }

            // check if such category already exist 

            Category? category_exist = await this.categoryRepository.GetAllAttachedNoTracking()
                .FirstOrDefaultAsync(c=> c.Name == model.Name && c.Division == model.Division && c.Gender == model.Gender);

            if (category_exist != null) 
            {
                // To Do handlig for message Category already exsit. 
                return false;
            }

            Category category = new Category() 
            {
                 Name = model.Name,
                 Division = model.Division,
                 Gender = model.Gender,
                 Creator_id = userId,
                 Changer_id = userId,
                 CreationDate = DateTime.UtcNow,
                 LastChangeDate = DateTime.UtcNow,
            };

           await categoryRepository.AddAsync(category);

            return true;
        }

        public async Task<IEnumerable<CategoriesDetailsViewModel>> GetAllCategories()
        {
            IEnumerable<CategoriesDetailsViewModel> model = this.categoryRepository.GetAllAttachedNoTracking().Select(c => new CategoriesDetailsViewModel() 
            {
                 Name = c.Name,
                 Gender = c.Gender,
                 Division = c.Division,
                 Id = c.Id.ToString(),
            }).ToList();

            return model;
        }
    }
}
