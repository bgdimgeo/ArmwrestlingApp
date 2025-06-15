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
        public IActionResult Details()
        {
            return View();
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


            this.competitionService.AddCompetitionAsync(model);

            return this.RedirectToAction(nameof(Index),controllerName:"Home");



        }
    }
}
