using ArmwrestlingApp.Services.Data.Interfaces;
using ArmwrestlingApp.ViewModels.Competition;
using ArmwrestlingApp.ViewModels.Team;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArmwrestlingApp.Controllers
{
    public class Team : BaseController
    {

        private readonly ITeamService teamService;

        public Team(ITeamService _teamService)
        {
            this.teamService = _teamService;
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
        public async Task<IActionResult> Create(CreateTeamViewModel model)
        {
            if (IsUserAuthenticated() == false)
            {
                return this.RedirectToAction(nameof(Index));
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }


            await this.teamService.AddTeamASync(model);

            return this.RedirectToAction(nameof(Index), controllerName: "Home");
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List(IEnumerable<CreateTeamViewModel> model)
        {
            IEnumerable<CreateTeamViewModel> viewModel = await this.teamService.GetAllTeamsAsync();


            return this.View(viewModel);
        }
    }
}
