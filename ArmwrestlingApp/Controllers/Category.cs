using ArmwrestlingApp.Services.Data.Interfaces;
using ArmwrestlingApp.ViewModels.Categorie;
using ArmwrestlingApp.ViewModels.Competition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArmwrestlingApp.Controllers
{
    public class Category : BaseController
    {
        private readonly ICategoryService categoryService;

        public Category(ICategoryService _categoryService)
        {
            this.categoryService = _categoryService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (IsUserAuthenticated() == false)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateViewModel model)
        {
            if (IsUserAuthenticated() == false)
            {
                return this.RedirectToAction(nameof(Index));
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.categoryService.AddCategoryAsync(model);

            return this.RedirectToAction(nameof(All));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            if (IsUserAuthenticated() == false)
            {
                return this.RedirectToAction(nameof(Index));
            }


            IEnumerable<CategoriesDetailsViewModel> viewModel = await this.categoryService.GetAllCategories();

            if (viewModel == null)
            {
                return this.RedirectToAction(nameof(Index), controllerName: "Home");
            }
            return this.View(viewModel);

        }


    }
}
