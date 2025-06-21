using System.Buffers.Text;
using System.Threading.Tasks;
using ArmwrestlingApp.Services.Data.Interfaces;
using ArmwrestlingApp.ViewModels.Competition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArmwrestlingApp.Controllers
{
    public class Competition : BaseController
    {
        private readonly ICompetitionService competitionService;

        public Competition(ICompetitionService _competitionService)
        {
            this.competitionService = _competitionService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {

            CompetitionDetailsViewModel model = await this.competitionService.GetCompetitionDetailsByIdAsync(id);


            return View(model);
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
        public async Task<IActionResult> Create(CompetitionCreateViewModel model)
        {
            if (IsUserAuthenticated() == false)
            {
                return this.RedirectToAction(nameof(Index));
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }


            await this.competitionService.AddCompetitionAsync(model);

            return this.RedirectToAction(nameof(Index), controllerName: "Home");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List(IEnumerable<CompetitionViewModel> model)
        {
            IEnumerable<CompetitionViewModel> viewModel = await this.competitionService.GetAllCompetitionsOrderedByDateAsync();


            return this.View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> All(CompetitionListViewModel model)
        {

            CompetitionListViewModel viewModel = await this.competitionService.GetAllCompetitionsOrderedByTypeAsync();

            if (viewModel == null)
            {
                return this.RedirectToAction(nameof(Index), controllerName: "Home");
            }
            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddCategory(string id)
        {

            CompetitionAddCategoryViewModel viewModel = await this.competitionService.GetCategoriesAsync(id);

            if (viewModel == null)
            {
                return this.RedirectToAction(nameof(List));
            }
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(CompetitionAddCategoryViewModel model)
        {

            if (IsUserAuthenticated() == false)
            {
                return this.RedirectToAction(nameof(Index));
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }


            await this.competitionService.AddCategoriesToCompetionAsync(model);

            return this.RedirectToAction(nameof(List));
        }
    }
}
