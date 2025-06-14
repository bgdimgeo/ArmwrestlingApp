namespace ArmwrestlingApp.ViewModels.Competitor
{
    public class CompetitorDetailsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Team { get; set; }

        public IEnumerable<CompetitorResultsViewModel> CompetitorResults { get; set; } = new List<CompetitorResultsViewModel>();
    }
}