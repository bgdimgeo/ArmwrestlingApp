using ArmwrestlingApp.ViewModels.Competition;
using ArmwrestlingApp.ViewModels.Competitor;

namespace ArmwrestlingApp.ViewModels.Categorie
{
    public class CategoriesDetailsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int ParticipantsCount { get; set; }

        public IEnumerable<CompetitorDetailsViewModel> Competitors { get; set; } = new List<CompetitorDetailsViewModel>();
    }
}